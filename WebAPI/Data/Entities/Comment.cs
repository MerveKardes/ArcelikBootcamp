namespace WebAPI.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }


    }
}
