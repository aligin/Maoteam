using AutoMapper;
using MaoTeam.Models.LocalUsers;
using MaoTeam.ViewModels.Users;
using System;

namespace MaoTeam.Configuration.MapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
