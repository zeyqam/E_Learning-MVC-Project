using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Categories
{
    public class CategoryEditVM
    {
        [Required(ErrorMessage = "This input can't be empty")]
        [StringLength(20)]
        public string Name { get; set; }
        public int Id { get; set; }

        

        public string CurrentImageUrl { get; set; }

        public IFormFile NewImage { get; set; }
    }
}
