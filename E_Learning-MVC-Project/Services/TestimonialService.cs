using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Testimonial;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TestimonialService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IEnumerable<TestimonialVM>> GetAllAsync()
        {
            return await _context.Testimonials.Select(m => new TestimonialVM
            {
                Id = m.Id,
                ClientName = m.ClientName,
                Profession = m.Profession,
                Content = m.Content,
                Image = m.Image
            }).ToListAsync();
        }

        public async Task<TestimonialVM> GetByIdAsync(int? id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null) return null;

            return new TestimonialVM
            {
                Id = testimonial.Id,
                ClientName = testimonial.ClientName,
                Profession = testimonial.Profession,
                Content = testimonial.Content,
                Image = testimonial.Image
            };
        }

        public async Task CreateAsync(TestimonialCreateVM request)
        {
           

            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;
            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.Image.CopyToAsync(stream);
            }

            var testimonial = new Testimonial
            {
                ClientName = request.ClientName,
                Profession = request.Profession,
                Content = request.Content,
                Image = fileName
            };

            await _context.Testimonials.AddAsync(testimonial);
            await _context.SaveChangesAsync();

            
        }

        public async Task EditAsync(int? id, TestimonialEditVM request)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                throw new Exception("Testimonil Not Found");
            } 

            if (request.NewImage != null)
            {
                

                string oldPath = Path.Combine(_env.WebRootPath, "img", testimonial.Image);
                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }

                string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await request.NewImage.CopyToAsync(stream);
                }

                testimonial.Image = fileName;
            }

            testimonial.ClientName = request.ClientName;
            testimonial.Profession = request.Profession;
            testimonial.Content = request.Content;

            await _context.SaveChangesAsync();

            
        }

        public async Task DeleteAsync(int? id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                throw new Exception("Testimonil not found");
            }
            string path = Path.Combine(_env.WebRootPath, "img", testimonial.Image);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();

            
        }
        public async Task<TestimonialEditVM> GetForEditAsync(int? id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null) return null;

            return new TestimonialEditVM
            {
                Id = testimonial.Id,
                ClientName = testimonial.ClientName,
                Profession = testimonial.Profession,
                Content = testimonial.Content,
                Image = testimonial.Image
            };
        }

        
    }
}
