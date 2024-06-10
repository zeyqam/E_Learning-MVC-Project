using E_Learning_MVC_Project.Models;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface IInstructorSocialService
    {
        Task<IEnumerable<InstructorSocial>> GetAllAsync();
    }
}
