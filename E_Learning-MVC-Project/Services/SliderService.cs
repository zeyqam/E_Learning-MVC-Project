using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Helpers.Extensions;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Slider;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _context.Sliders.ToListAsync();
        }
        public async Task<List<SliderVM>> GetSlidersAsync()
        {
            return await _context.Sliders
                                 .Select(m => new SliderVM { Id = m.Id, Image = m.Image })
                                 .ToListAsync();
        }

        public async Task CreateSliderAsync(SliderCreateVM request)
        {
            foreach (var item in request.Images)
            {
                if (!item.CheckFileType("image/"))
                {
                    throw new Exception("Input can accept only image format");
                }
                if (!item.CheckFileSize(200))
                {
                    throw new Exception("Image size must be max 200kb");
                }

                string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;
                string path = _env.GenerateFilePath("img", fileName);
                await item.SaveFileLocalAsync(path);

                await _context.Sliders.AddAsync(new Slider { Image = fileName });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSliderAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                throw new Exception("Slider not found");
            }

            string path = _env.GenerateFilePath("img", slider.Image);
            path.DeleteFileFromLocal();
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<SliderEditVM> GetSliderForEditAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                throw new Exception("Slider not found");
            }

            return new SliderEditVM { Image = slider.Image };
        }

        public async Task EditSliderAsync(int id, SliderEditVM request)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                throw new Exception("Slider not found");
            }

            if (request.NewImage == null)
            {
                return;
            }

            if (!request.NewImage.CheckFileType("image/"))
            {
                throw new Exception("Input can accept only image format");
            }

            if (!request.NewImage.CheckFileSize(200))
            {
                throw new Exception("Image size must be max 200kb");
            }

            string oldPath = _env.GenerateFilePath("img", slider.Image);
            oldPath.DeleteFileFromLocal();

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
            string newPath = _env.GenerateFilePath("img", fileName);
            await request.NewImage.SaveFileLocalAsync(newPath);

            slider.Image = fileName;
            await _context.SaveChangesAsync();
        }
    }
}
