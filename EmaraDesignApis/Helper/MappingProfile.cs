using AutoMapper;
using EmaraDesignWebApi.Dto;
using EmaraDesignWebApi.Models;

namespace EmaraDesignWebApi.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectImage, ProjectImageGetDto>();
            CreateMap<CreateProjectDto, Project>();
            CreateMap<Project, GetProjectDto>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));


        }
    }
}
