using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Learning_MVC_Project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        private readonly ISettingService _settigservice;
        private readonly UserManager<AppUser> _userManager;

        public HeaderViewComponent(ISettingService settingService,UserManager<AppUser> userManager)
        {
            _settigservice = settingService;
            _userManager = userManager;


        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            AppUser user=new AppUser();
            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            

            Dictionary<string, string> settings = await _settigservice.GetAllAsync();
            HeaderVM response = new()
            {
                Settings = settings,
                UserFullName= user.FullName
            };
            return await Task.FromResult(View(response));
        }
        public class HeaderVM
        {


            public Dictionary<string, string> Settings { get; set; }
            public string UserFullName { get; set; }
            public bool IsAuthenticated { get; set; }
        }


    }
    
}
