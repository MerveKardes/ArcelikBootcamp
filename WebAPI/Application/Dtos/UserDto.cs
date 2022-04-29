namespace WebAPI.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Message { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int RoleId { get; set; }
    }
}
