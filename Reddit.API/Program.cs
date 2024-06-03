using Microsoft.Extensions.FileProviders;
using Reddit.API.Startup;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureLogging();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.ConfigIdentityService();
builder.Services.AddBussinessService();
builder.Services.ConfigureSwagger();

#pragma warning disable CS8604 // Possible null reference argument.
builder.Services.AddJWTAuthentication(builder.Configuration["Jwt:Key"], builder.Configuration["Jwt:Issuer"]);
#pragma warning restore CS8604 // Possible null reference argument.

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("http://localhost:3000");
}));

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory() + "/wwwroot")
//});

app.MapControllers();

app.MapGet("/Test", async (ILogger<Program> logger, HttpResponse response) =>
{
    logger.LogInformation("Testing logging in Program.cs");
    await response.WriteAsync("Testing");
});

app.UseForwardedHeaders();

app.Run();
