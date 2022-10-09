
namespace AuthProject.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
