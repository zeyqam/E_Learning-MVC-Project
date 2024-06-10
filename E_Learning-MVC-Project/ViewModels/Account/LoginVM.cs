using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        public string EmailorUsername { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
