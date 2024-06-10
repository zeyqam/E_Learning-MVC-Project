using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Helpers.Extensions;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Instructor;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class InstructorService:IInstructorService
    {


        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public InstructorService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructors.Include(m => m.InstructorSocials).ToListAsync();
        }

        public async Task CreateAsync(InstructorCreateVM request)
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

                await _context.Instructors.AddAsync(new Instructor { Name = request.Name, Designation = request.Designation, Image = fileName });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                throw new Exception("Instructor not found");
            }

            string path = _env.GenerateFilePath("img", instructor.Image);
            path.DeleteFileFromLocal();
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task<InstructorEditVM> GetForEditAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                throw new Exception("Instructor not found");
            }

            return new InstructorEditVM { Name = instructor.Name, Designation = instructor.Designation };
        }

        public async Task EditAsync(int id, InstructorEditVM request)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                throw new Exception("Instructor not found");
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

            string oldPath = _env.GenerateFilePath("img", instructor.Image);
            oldPath.DeleteFileFromLocal();

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
            string newPath = _env.GenerateFilePath("img", fileName);
            await request.NewImage.SaveFileLocalAsync(newPath);

            instructor.Image = fileName;
            await _context.SaveChangesAsync();
        }
    }
}
