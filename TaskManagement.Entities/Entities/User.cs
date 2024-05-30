using TaskManagement.Entities.Entities.Common;

namespace TaskManagement.Entities.Entities
{
    public class User : BaseEntity
    {
        public int RoleId { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
