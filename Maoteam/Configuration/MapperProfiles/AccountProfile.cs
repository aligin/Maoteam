using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maoteam.Configuration.MapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            //CreateMap<AutomatonLibraryViewModel, GateAutomatonLibraryViewModel>()
            //    .ForMember(dst => dst.Size, opt => opt.MapFrom(src => src.FilesSize))
            //    .ForMember(dst => dst.EntityInfo, opt => opt.MapFrom(src => src.EntityInfo));
        }
    }
}
