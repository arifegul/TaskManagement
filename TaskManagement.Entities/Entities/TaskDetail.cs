using TaskManagement.Entities.Entities.Common;

namespace TaskManagement.Entities.Entities
{
    public class TaskDetail : BaseEntity
    {
        public int TaskId { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TaskStatus { get; set; } // 0-todo 1-inprogress 2-done
        public required Tasks Task { get; set; }
    }
}
