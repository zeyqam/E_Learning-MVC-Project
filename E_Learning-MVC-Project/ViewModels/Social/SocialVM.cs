using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Social
{
    public class SocialVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<int> InstructorIds { get; set; }
        public List<SelectListItem> Instructors { get; set; }
    }
}
