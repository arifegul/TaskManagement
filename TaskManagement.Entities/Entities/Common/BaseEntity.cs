namespace TaskManagement.Entities.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
        public string? CreatedBy { get; set; } 
        public string? ModifiedBy { get; set; }
    }
}
