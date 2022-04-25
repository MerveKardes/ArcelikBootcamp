namespace WebAPI.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Message { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Film> Films { get; set; } = new List<Film>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<ReceiverMessage> ReceiverMessages { get; set; } = new List<ReceiverMessage>();
        public List<SenderMessage> SenderMessages { get; set; } = new List<SenderMessage>();
    }
}
