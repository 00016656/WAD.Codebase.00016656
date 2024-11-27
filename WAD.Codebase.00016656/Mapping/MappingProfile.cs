namespace WAD.Codebase._00016656.Mapping
{
    using AutoMapper;
    using WAD.Codebase._00016656.Dtos;
    using WAD.Codebase._00016656.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mapping
            CreateMap<User, UserDTO>();

            // Property Mapping
            CreateMap<Property, PropertyDTO>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName));

            // CreatePropertyDTO to Property Mapping
            CreateMap<CreatePropertyDTO, Property>();

            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Hashing will be handled separately
        }
    }

}
