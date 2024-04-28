using System.ComponentModel.DataAnnotations;

namespace EmaraDesignWebApi.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
