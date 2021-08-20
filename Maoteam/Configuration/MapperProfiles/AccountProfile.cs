using AutoMapper;
using MaoTeam.Models.LocalUsers;
using MaoTeam.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaoTeam.Configuration.MapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.Uid, x => x.MapFrom(x => x.Id));
        }
    }
}
