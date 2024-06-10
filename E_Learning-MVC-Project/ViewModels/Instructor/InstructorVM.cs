using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.InstructorSocial;

namespace E_Learning_MVC_Project.ViewModels.Instructor
{
    public class InstructorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Image { get; set; }

        public List<InstructorSocialVM> InstructorSocials { get; set; }
    }
}
