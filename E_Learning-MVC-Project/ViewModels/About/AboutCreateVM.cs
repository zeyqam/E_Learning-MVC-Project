using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.About
{
    public class AboutCreateVM
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
