using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.Categories;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryVM>> GetAllAsync();
        Task<CategoryVM> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateVM categoryCreateVM);
        Task UpdateAsync(int id, CategoryEditVM categoryEditVM);
        Task DeleteAsync(int id);

    }
}
