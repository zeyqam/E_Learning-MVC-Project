using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Social
{
    public class SocialVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }
    }
}
