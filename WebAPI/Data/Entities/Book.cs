namespace WebAPI.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Writer { get; set; } = String.Empty;
        public int Point { get; set; }
        public bool IsFavorite { get; set; }
    }
}
