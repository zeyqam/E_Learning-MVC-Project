namespace E_Learning_MVC_Project.Models
{
    public class Testimonial:BaseEntity
    {
       
        public string ClientName { get; set; }
        public string Profession { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
    }
}
