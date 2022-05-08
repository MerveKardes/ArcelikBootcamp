namespace WebAPI.Application.Dtos
{
    public class SenderMessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int? UserId { get; set; }
        public string Username { get; set; } = String.Empty;
    }
}
