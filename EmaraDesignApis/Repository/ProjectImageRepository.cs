using EmaraDesignWebApi.Data;
using EmaraDesignWebApi.Interfaces;
using EmaraDesignWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmaraDesignWebApi.Repository
{
    public class ProjectImageRepository:IProjectImageRepository
    {
        private readonly AppDbContext _context;

        public ProjectImageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProjectImage>> GetImagesByPIdAsync(int id)
        {
            return await _context.ProjectImages.Where(p => p.ProjectId == id).ToListAsync();
        }
    }
}
