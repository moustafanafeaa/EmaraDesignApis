using AutoMapper;
using EmaraDesignWebApi.Dto;
using EmaraDesignWebApi.Helper;
using EmaraDesignWebApi.INterfaces;
using EmaraDesignWebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmaraDesignWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper; //to map data to it't DTOs

        public ProjectController(IProjectRepository projectRepositry, IMapper mapper, Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager)
        {
            _projectRepository = projectRepositry;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var projects = await _projectRepository.GetAllAsync();


            var data = _mapper.Map<IEnumerable<GetProjectDto>>(projects);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (! await _projectRepository.ProjectExistsAsync(id)) { return NotFound("No Project with this ID"); }

            var project = await _projectRepository.GetByIdAsync(id);

            var data = _mapper.Map<GetProjectDto>(project);

            return Ok(data);
        }

        [HttpPost]

        public async Task<IActionResult> AddProjectAsync(CreateProjectDto dto)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //if(string.IsNullOrEmpty(userId))
            //    return BadRequest("UserNotFound");

            var userExists = await _userManager.FindByIdAsync(dto.UserId);
            if (userExists == null) return BadRequest("User Not Found");

            var project = _mapper.Map<Project>(dto);
            project.UserId = dto.UserId;
            await _projectRepository.AddProjectAsync(project);

            var data = _mapper.Map<GetProjectDto>(project);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync(int id)
        {
            var ProjectExists = await _projectRepository.ProjectExistsAsync(id);
            if (!ProjectExists) { return NotFound($"NO Project with id {id}"); }

            var deletedProject = await _projectRepository.DeleteProjectAsync(id);

            var dto = _mapper.Map<GetProjectDto>(deletedProject);
          
            return Ok(dto);
        }



    }
}
