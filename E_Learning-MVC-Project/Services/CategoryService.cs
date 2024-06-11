using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Helpers.Extensions;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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

        public async Task CreateAsync(CategoryCreateVM request)
        {
            if (!request.Image.CheckFileType("image/"))
            {
                throw new Exception("Sadece resim formatı kabul edilir");
            }

            if (!request.Image.CheckFileSize(200))
            {
                throw new Exception("Resim boyutu en fazla 200kb olmalıdır");
            }

            var fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;
            var filePath = _env.GenerateFilePath("img", fileName);
            await request.Image.SaveFileLocalAsync(filePath);

            var category = new Category
            {
                Name = request.Name,
                ImageUrl = fileName
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı");
            }

            var imagePath = _env.GenerateFilePath("img", category.ImageUrl);
            imagePath.DeleteFileFromLocal();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CategoryEditVM request)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı");
            }

            if (request.NewImage != null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    throw new Exception("Sadece resim formatı kabul edilir");
                }

                if (!request.NewImage.CheckFileSize(200))
                {
                    throw new Exception("Resim boyutu en fazla 200kb olmalıdır");
                }

                var oldImagePath = _env.GenerateFilePath("img", category.ImageUrl);
                oldImagePath.DeleteFileFromLocal();

                var newFileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
                var newFilePath = _env.GenerateFilePath("img", newFileName);
                await request.NewImage.SaveFileLocalAsync(newFilePath);

                category.ImageUrl = newFileName;
            }

            category.Name = request.Name;
            await _context.SaveChangesAsync();
        }

    }
}
