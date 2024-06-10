using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Testimonial
{
    public class TestimonialEditVM
    {
        public int Id { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        
        public string Content { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
    }
}
