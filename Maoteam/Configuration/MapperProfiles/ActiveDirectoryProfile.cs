using AutoMapper;
using MaoTeam.Models;
using MaoTeam.Models.LocalUsers;
using MaoTeam.ViewModels.Users;
using System;

namespace MaoTeam.Configuration.MapperProfiles
{
    public class ActiveDirectoryProfile : Profile
    {
        public ActiveDirectoryProfile()
        {
            CreateMap<AdUser, User>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.ObjectSid))
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.SamAccountName))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.GivenName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Sn))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.TelephoneNumber))
                .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.WhenCreated))
                .ForMember(dst => dst.UpdatedAt, opt => opt.MapFrom(src => src.WhenChanged))
                .ForMember(dst => dst.FailedLoginAppempts, opt => opt.MapFrom(src => src.BadPwdCount))
                .ForMember(dst => dst.LastLogon, opt => opt.MapFrom(src => src.LastLogon));

        }
    }
}
