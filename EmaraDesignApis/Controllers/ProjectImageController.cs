using AutoMapper;
using EmaraDesignWebApi.Dto;
using EmaraDesignWebApi.Interfaces;
using EmaraDesignWebApi.INterfaces;
using EmaraDesignWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmaraDesignWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectImageController : ControllerBase
    {
        private readonly IProjectImageRepository _projectImage;
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;



        public ProjectImageController(IProjectImageRepository projectImage, IMapper mapper, IProjectRepository projectRepository)
        {
            _projectImage = projectImage;
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        [HttpGet("{id}",Name ="AllImages")]
        public async Task<IActionResult> GetImagesByPIdAsync(int id)
        {
           
            if (! await _projectRepository.ProjectExistsAsync(id))
                { return NotFound("No Project with this ID");}

            var images = await _projectImage.GetImagesByPIdAsync(id);
           
            var MainImage = await _projectRepository.GetByIdAsync(id);
            if (images.FirstOrDefault() == null ) { return Ok("Main Image " + MainImage.MainImage); }

            var result = _mapper.Map< IEnumerable<ProjectImageGetDto>>(images);
            return Ok(result);
        }

        
    }
}
