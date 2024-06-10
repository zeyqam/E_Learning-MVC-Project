using Microsoft.AspNetCore.Identity;

namespace E_Learning_MVC_Project.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }

    }
}
