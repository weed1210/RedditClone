using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Reddit.DataAccess.UnitOfWork;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;
using Reddit.Service.Core;
using Reddit.Service.Core.Abstractions;
using Reddit.Service.Mapping;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Reddit.API.Startup;

public static class StartupExtensions
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<RedditDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("Supabase"),
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
        });
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MemberMapperProfile());
            mc.AddProfile(new StaffMapperProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
    }

    public static void AddBussinessService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IUserService, UserService>();
    }

    public static void ConfigIdentityService(this IServiceCollection services)
    {
        var idenityOptions = (IdentityOptions x) =>
        {
            x.SignIn.RequireConfirmedAccount = false;
            x.User.RequireUniqueEmail = false;
            x.Password.RequireDigit = false;
            x.Password.RequiredLength = 8;
            x.Password.RequireNonAlphanumeric = false;
            x.Password.RequireUppercase = false;
            x.Password.RequireLowercase = false;
            x.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            x.User.RequireUniqueEmail = true;
            x.SignIn.RequireConfirmedAccount = false;
        };

        var build = services.AddIdentityCore<User>(idenityOptions);

        build.AddRoles<Role>().AddEntityFrameworkStores<RedditDbContext>().AddDefaultTokenProviders();
        build.AddSignInManager<SignInManager<User>>();
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<RedditDbContext>()
            .AddUserManager<UserManager<User>>()
            .AddRoleManager<RoleManager<Role>>()
            .AddDefaultTokenProviders();
        services.AddAuthorization();
    }

    public static void AddJWTAuthentication(this IServiceCollection services, string key, string issuer)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtconfig =>
            {
                jwtconfig.SaveToken = true;
                jwtconfig.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateAudience = false,
                    ValidIssuer = issuer,
                    ValidateIssuer = true,
                    ValidateLifetime = false,
                    RequireAudience = false,
                };
                jwtconfig.Events = new JwtBearerEvents()
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";

                        // Ensure we always have an error and error description.
                        if (string.IsNullOrEmpty(context.Error))
                            context.Error = "invalid_token";
                        if (string.IsNullOrEmpty(context.ErrorDescription))
                            context.ErrorDescription = "This request requires a valid JWT access token to be provided";

                        // Add some extra context for expired tokens.
                        if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            var authenticationException = context.AuthenticateFailure as SecurityTokenExpiredException;
                            context.Response.Headers.Add("x-token-expired", authenticationException?.Expires.ToString("o"));
                            context.ErrorDescription = $"The token expired on {authenticationException?.Expires.ToString("o")}";
                        }

                        return context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            error = context.Error,
                            error_description = context.ErrorDescription
                        }));
                    },
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (path.StartsWithSegments("/notificationHub"))
                        {
                            // Read the token out of the query string 
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "OnlineMarketplaceSystem",
                Version = "v1.1.k8s",
                Description = "Online Marketplace System",
            });
            c.UseInlineDefinitionsForEnums();
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Add OnlineMarketplaceSystem Bearer Token Here",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Name = "Bearer"
                    },
                    new List<string>()
                }
            });
        });

        services.AddControllersWithViews().AddNewtonsoftJson(options =>
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));
        services.AddSwaggerGenNewtonsoftSupport();
    }

    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddConsole();
    }
}
