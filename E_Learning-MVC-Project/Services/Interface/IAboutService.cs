using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.About;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface IAboutService
    {
        Task<IEnumerable<AboutVM>> GetAllAsync();
        Task<AboutVM> GetByIdAsync(int id);
        Task CreateAsync(AboutCreateVM request);
        Task DeleteAsync(int id);
        Task<AboutEditVM> GetForEditAsync(int id);
        Task EditAsync(int id, AboutEditVM request);
    }
}
