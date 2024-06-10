using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.About;
using E_Learning_MVC_Project.ViewModels.Testimonial;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface ITestimonialService
    {


        Task<IEnumerable<TestimonialVM>> GetAllAsync();
        Task<TestimonialVM> GetByIdAsync(int? id);
        Task<TestimonialEditVM> GetForEditAsync(int?id);
        Task CreateAsync(TestimonialCreateVM request);
        Task EditAsync(int? id, TestimonialEditVM request);
        Task DeleteAsync(int? id);
    }
}
