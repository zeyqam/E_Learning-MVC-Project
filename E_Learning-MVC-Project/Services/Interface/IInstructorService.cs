using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.Instructor;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface IInstructorService
    {

        Task<IEnumerable<Instructor>> GetAllAsync();
        Task CreateAsync(InstructorCreateVM request);
        Task DeleteAsync(int id);
        Task<InstructorEditVM> GetForEditAsync(int id);
        Task EditAsync(int id, InstructorEditVM request);
    }
}

