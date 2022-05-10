namespace WebAPI.Application.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int MovieId { get; set; }
        public DateTime Date { get; set; }
    }
}
