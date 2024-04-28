using System.ComponentModel.DataAnnotations;

namespace EmaraDesignWebApi.Models
{
    public class ProjectImage
    {
        public int ImageId { get; set; }
        public string ImageDetailsUrl { get; set; }


        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
