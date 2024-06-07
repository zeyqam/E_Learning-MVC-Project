using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
