namespace E_Learning_MVC_Project.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool SofDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
