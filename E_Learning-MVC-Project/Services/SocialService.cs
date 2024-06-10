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

        public async Task<IEnumerable<Social>> GetAllAsync()
        {
            return await _context.Socials.Where(m => !m.SofDeleted).ToListAsync();
        }

        public async Task<Social> GetByIdAsync(int id)
        {
            return await _context.Socials.FindAsync(id);
        }

        public async Task CreateAsync(Social social)
        {
            await _context.Socials.AddAsync(social);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Social social)
        {
            _context.Socials.Update(social);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var social = await _context.Socials.FindAsync(id);
            if (social != null)
            {
                social.SofDeleted = true;
                await _context.SaveChangesAsync();
            }

        }

        public IEnumerable<SocialVM> GetMappeDatas(IEnumerable<Social> socials)
        {
            return socials.Select(m => new SocialVM
            {
                Id = m.Id,
                Name = m.Name,
                Url = m.Url
                
                


            });
        }

    }
}
