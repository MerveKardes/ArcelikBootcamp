namespace WebAPI.Data.Entities
{
    public class SenderMessage
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int? UserId { get; set; }
        public User? User { get; set; }
      
    }
}
