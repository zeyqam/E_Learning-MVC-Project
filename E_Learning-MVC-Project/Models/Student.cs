namespace E_Learning_MVC_Project.Models
{
    public class Student:BaseEntity
    {
        
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
