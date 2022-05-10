namespace WebAPI.Application.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Writer { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public int Point { get; set; }
        public bool IsFavorite { get; set; }
    }
}
