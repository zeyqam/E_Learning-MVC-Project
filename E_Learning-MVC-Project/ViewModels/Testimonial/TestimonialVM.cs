using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Testimonial
{
    public class TestimonialVM
    {

        public int Id { get; set; }

        
        public string ClientName { get; set; }

      
        public string Profession { get; set; }

        
        public string Content { get; set; }

        public string Image { get; set; }

        
    }
}
