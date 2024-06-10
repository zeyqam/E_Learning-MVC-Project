using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var categories = await _context.Categories
                .Where(c => !c.SofDeleted)
                .Select(c => new CategoryVM
                {
                    Id = c.Id,
                    CategoryName = c.Name,
                    
                })
                .ToListAsync();

            return categories;
        }

        public async Task<CategoryVM> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id && !c.SofDeleted)
                .Select(c => new CategoryVM
                {
                    Id = c.Id,
                    CategoryName = c.Name,
                    Image = c.ImageUrl
                })
                .FirstOrDefaultAsync();

            return category;
        }

        public async Task CreateAsync(CategoryCreateVM categoryCreateVM)
        {
            var category = new Category
            {
                Name = categoryCreateVM.Name,
                ImageUrl = SaveImage(categoryCreateVM.Image)
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CategoryEditVM categoryEditVM)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                category.Name = categoryEditVM.Name;
                if (categoryEditVM.NewImage!= null)
                {
                    category.ImageUrl = SaveImage(categoryEditVM.NewImage);
                }

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                category.SofDeleted = true;
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
        }

        private string SaveImage(IFormFile image)
        {
            if (image == null)
                return null;

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}
