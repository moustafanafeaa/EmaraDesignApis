using EmaraDesignWebApi.Models;

namespace EmaraDesignWebApi.Interfaces
{
    public interface IProjectImageRepository
    {
        Task<IEnumerable<ProjectImage>> GetImagesByPIdAsync(int id);
    }
}
