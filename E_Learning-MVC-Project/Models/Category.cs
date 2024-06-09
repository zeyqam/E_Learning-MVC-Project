namespace E_Learning_MVC_Project.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
