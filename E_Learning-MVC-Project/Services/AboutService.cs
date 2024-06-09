using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Helpers.Extensions;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.About;
using E_Learning_MVC_Project.ViewModels.Information;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IEnumerable<AboutVM>> GetAllAsync()
        {
            return await _context.Abouts
                                 .Select(m => new AboutVM
                                 {
                                     Id = m.Id,
                                     Title = m.Title,
                                     Description = m.Description,
                                     Image = m.Image
                                 })
                                 .ToListAsync();
        }

        public async Task<AboutVM> GetByIdAsync(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about == null) return null;

            return new AboutVM
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                Image = about.Image
            };
        }

        public async Task CreateAsync(AboutCreateVM request)
        {
            if (!request.Image.CheckFileType("image/"))
            {
                throw new Exception("Input can accept only image format");
            }

            if (!request.Image.CheckFileSize(200))
            {
                throw new Exception("Image size must be max 200kb");
            }

            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;
            string path = _env.GenerateFilePath("img", fileName);
            await request.Image.SaveFileLocalAsync(path);

            var about = new About
            {
                Title = request.Title,
                Description = request.Description,
                Image = fileName
            };

            await _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                throw new Exception("About not found");
            }

            string path = _env.GenerateFilePath("img", about.Image);
            path.DeleteFileFromLocal();

            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
        }

        public async Task<AboutEditVM> GetForEditAsync(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                throw new Exception("About not found");
            }

            return new AboutEditVM
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                Image = about.Image
            };
        }

        public async Task EditAsync(int id, AboutEditVM request)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                throw new Exception("About not found");
            }

            if (request.NewImage != null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    throw new Exception("Input can accept only image format");
                }

                if (!request.NewImage.CheckFileSize(200))
                {
                    throw new Exception("Image size must be max 200kb");
                }

                string oldPath = _env.GenerateFilePath("img", about.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
                string newPath = _env.GenerateFilePath("img", fileName);
                await request.NewImage.SaveFileLocalAsync(newPath);

                about.Image = fileName;
            }

            about.Title = request.Title;
            about.Description = request.Description;
            await _context.SaveChangesAsync();
        }


    }
       
}
