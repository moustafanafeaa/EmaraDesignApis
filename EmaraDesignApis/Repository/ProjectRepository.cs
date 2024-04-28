using EmaraDesignWebApi.Data;
using EmaraDesignWebApi.INterfaces;
using EmaraDesignWebApi.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Project = EmaraDesignWebApi.Models.Project;

namespace EmaraDesignWebApi.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.Include(u=>u.User).ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.Include(u => u.User).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<bool> ProjectExistsAsync(int id) 
        { 
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            var createdProject = await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            var cre= await _context.Projects.Include(x=>x.User).FirstOrDefaultAsync(x=>x.Id==createdProject.Entity.Id);

            //var newproject = await _context.Projects.Include(x=>x.User).FirstOrDefaultAsync(x=>x.Id==createdProject.Entity.Id);
            return cre;
        }

        public async Task<Project> DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.Include(x => x.User).FirstOrDefaultAsync(x=>x.Id==id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }



    }
}
