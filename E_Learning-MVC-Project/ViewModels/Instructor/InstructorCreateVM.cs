using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.InstructorSocial;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Instructor
{
    public class InstructorCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public IEnumerable< IFormFile> Images { get; set; }
        public List<InstructorSocialVM> Socials { get; set; }
    }
}
