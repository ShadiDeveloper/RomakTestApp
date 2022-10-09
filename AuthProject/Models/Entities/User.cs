namespace AuthProject.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
