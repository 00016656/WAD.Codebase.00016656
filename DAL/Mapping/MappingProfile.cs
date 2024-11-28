using AutoMapper;
using WAD.Codebase._00016656.Dtos;
using WAD.Codebase._00016656.Models;

namespace WAD.Codebase._00016656.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mapping
            CreateMap<User, UserDTO>().ReverseMap();

            // Property Mapping
            CreateMap<Property, PropertyDTO>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName))
                .ReverseMap();

            CreateMap<Property, PropertyEditDTO>().ReverseMap();

            // CreatePropertyDTO to Property Mapping
            CreateMap<CreatePropertyDTO, Property>();

            // CreateUserDTO to User Mapping
            CreateMap<CreateUserDTO, User>();
        }
    }
}
