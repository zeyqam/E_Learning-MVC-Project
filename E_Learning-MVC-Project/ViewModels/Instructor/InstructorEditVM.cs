using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.InstructorSocial;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Instructor
{
    public class InstructorEditVM
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Designation { get; set; }
        public IFormFile NewImage { get; set; } 
        public List<InstructorSocialVM> Socials { get; set; }
    }
    
}
