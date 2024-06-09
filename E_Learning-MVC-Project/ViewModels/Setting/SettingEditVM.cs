using Microsoft.AspNetCore.Mvc;

namespace E_Learning_MVC_Project.ViewModels.Setting
{
    public class SettingEditVM

    {
        
        [HiddenInput(DisplayValue = false)]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
