using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class InstructorSocilaService : IInstructorSocialService
    {
        private readonly AppDbContext _context;
        public InstructorSocilaService(AppDbContext context)
        {
            _context = context;
        }
        public async  Task<IEnumerable<InstructorSocial>> GetAllAsync()
        {
            return await _context.InstructorSocials.Include(s => s.Social).ToListAsync();
        }
    }
}

