using E_Learning_MVC_Project.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Learning_MVC_Project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        private readonly ISettingService _settigservice;

        public HeaderViewComponent(ISettingService settingService)
        {
            _settigservice = settingService;


        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            Dictionary<string, string> settings = await _settigservice.GetAllAsync();
            HeaderVM response = new()
            {
                Settings = settings

            };
            return await Task.FromResult(View(response));
        }
        public class HeaderVM
        {


            public Dictionary<string, string> Settings { get; set; }


        }
    }
}
