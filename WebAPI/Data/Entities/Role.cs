namespace WebAPI.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }=String.Empty;
        public List<User>? Users { get; set; }
    }
}
