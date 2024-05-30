using TaskManagement.Entities.Entities.Common;

namespace TaskManagement.Entities.Entities
{
    public class Tasks : BaseEntity
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public User User { get; set; }
    }
}
