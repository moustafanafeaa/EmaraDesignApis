using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EmaraDesignWebApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; } 

        public string MainImage { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<ProjectImage>? ImagesDetails { get; set; }


        public string UserId { get; set; }

        [Required]
        public IdentityUser User { get; set; }



        public void UpdateTimeNow()
        {
            UpdateTime = DateTime.Now;
        }
    }

}
