using E_Learning_MVC_Project.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_MVC_Project.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly ISettingService _settigservice;

        public FooterViewComponent(ISettingService settingService)
        {
            _settigservice = settingService;


        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            Dictionary<string, string> settings = await _settigservice.GetAllAsync();
            FooterVMVC response = new()
            {
                Settings = settings

            };
            return await Task.FromResult(View(response));
        }
        public class FooterVMVC
        {


            public Dictionary<string, string> Settings { get; set; }


        }

    }
}
