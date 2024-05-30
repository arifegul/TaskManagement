namespace TaskManagement.Entities.Dtos
{
    public class RoleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
