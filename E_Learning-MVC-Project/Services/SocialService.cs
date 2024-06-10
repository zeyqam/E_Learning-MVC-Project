using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Social;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class SocialService : ISocialService
    {
        private readonly AppDbContext _context;

        public SocialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstructorSocial>> GetAllAsync()
        {
            return await _context.InstructorSocials.Include(m => m.Instructor).ToListAsync();
        }

        public async Task<Social> GetByIdAsync(int id)
        {
            return await _context.Socials.Include(s => s.InstructorSocials).ThenInclude(m => m.Instructor).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateAsync(Social social)
        {
            _context.Socials.Add(social);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Social social)
        {
            _context.Socials.Update(social);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var social = await GetByIdAsync(id);
            _context.Socials.Remove(social);
            await _context.SaveChangesAsync();
        }

        
    }

}
