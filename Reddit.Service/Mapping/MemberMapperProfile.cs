using AutoMapper;
using Reddit.Contract.Member;
using Reddit.Domain.Entities;

namespace Reddit.Service.Mapping;
public class MemberMapperProfile : Profile
{
    public MemberMapperProfile()
    {
        CreateMap<Member, MemberModel>();
        CreateMap<MemberRegisterModel, Member>()
            .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToLower()))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email.ToLower()))
            .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.Email.ToLower()));
    }
}
