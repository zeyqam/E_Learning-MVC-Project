using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage = "Input can't be empty")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        
        public IFormFile ImageFile { get; set; }

    }
}

