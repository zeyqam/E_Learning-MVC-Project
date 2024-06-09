namespace E_Learning_MVC_Project.Models
{
    public class InstructorSocial:BaseEntity
    {

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int SocialId { get; set; }
        public Social Social { get; set; }
    }
}
