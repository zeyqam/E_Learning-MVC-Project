using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.Setting;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface ISettingService
    {
        Task<Dictionary<string, string>> GetAllAsync();
        Task<Setting> GetByKeyAsync(string key); 
        Task UpdateAsync(string key, string value);
    }
}
