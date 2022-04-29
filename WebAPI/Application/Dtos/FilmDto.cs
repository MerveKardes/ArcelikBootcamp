namespace WebAPI.Application.Dtos
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Summary { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
        public int Point { get; set; }
        public bool IsFavorite { get; set; }
    }
}
