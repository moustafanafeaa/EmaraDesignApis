namespace EmaraDesignWebApi.Dto
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string MainImage { get; set; }

        public string UserId { get; set; }

    }
}
