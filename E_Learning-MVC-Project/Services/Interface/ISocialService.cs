using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.Social;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface ISocialService
    {

        Task<IEnumerable<Social>> GetAllAsync();
        Task<Social> GetByIdAsync(int id);
        Task CreateAsync(Social social);
        Task UpdateAsync(Social social);
        Task DeleteAsync(int id);
        IEnumerable<SocialVM> GetMappeDatas(IEnumerable<Social> socials);
    }
}
