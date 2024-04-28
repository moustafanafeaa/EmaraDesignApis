using Microsoft.AspNetCore.Identity;

namespace EmaraDesignWebApi.Dto
{
    public class GetProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainImage { get; set; }
        public string UserName { get; set; }
    }
}
