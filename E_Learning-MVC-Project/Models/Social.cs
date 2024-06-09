namespace E_Learning_MVC_Project.Models
{
    public class Social:BaseEntity
    {
        
        public string Name { get; set; }
        public string Url { get; set; }

        public ICollection<InstructorSocial> InstructorSocials { get; set; }
    }
}
