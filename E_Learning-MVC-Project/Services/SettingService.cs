using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Setting;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        public SettingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }

        public async Task<Setting> GetByKeyAsync(string key)
        {
            return await _context.Settings.FirstOrDefaultAsync(m => m.Key == key);
        }


        public async Task UpdateAsync(string key, string value)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync(m => m.Key == key);
            if (setting != null)
            {
                setting.Value = value;
                await _context.SaveChangesAsync();
            }
        }
    }

        
    
}


