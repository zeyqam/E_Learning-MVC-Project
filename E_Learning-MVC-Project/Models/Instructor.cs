namespace E_Learning_MVC_Project.Models
{
    public class Instructor : BaseEntity
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<InstructorSocial> InstructorSocials { get; set; }
        public ICollection<Course> Courses { get; set; }

    }




}
