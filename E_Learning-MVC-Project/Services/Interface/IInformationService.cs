using E_Learning_MVC_Project.ViewModels.Information;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface IInformationService
    {
        Task<IEnumerable<InformationVM>> GetAllAsync();
        Task<InformationVM> GetByIdAsync(int id);
        Task CreateAsync(InformationVM informationVM);
        Task UpdateAsync(InformationVM informationVM);
        Task DeleteAsync(int id);
    }
}
