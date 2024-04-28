using EmaraDesignWebApi.Models;

namespace EmaraDesignWebApi.INterfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);

        Task<bool> ProjectExistsAsync(int id);

        Task<Project> AddProjectAsync(Project project);
        Task<Project> DeleteProjectAsync(int id);

    }

}
