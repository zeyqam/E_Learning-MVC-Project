using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Testimonial
{
    public class TestimonialCreateVM
    {
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Profession { get; set; }


        [Required]
        public string Content { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
