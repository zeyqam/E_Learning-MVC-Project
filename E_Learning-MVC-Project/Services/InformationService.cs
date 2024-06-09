using E_Learning_MVC_Project.Data;
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Information;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Services
{
    public class InformationService:IInformationService
    {
        private readonly AppDbContext _context;

        public InformationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InformationVM>> GetAllAsync()
        {
            return await _context.Informations
                .Select(m => new InformationVM
                {
                    Id = m.Id,
                    
                    
                    Title = m.Title,
                    Description = m.Description
                })
                .ToListAsync();
        }

        public async Task<InformationVM> GetByIdAsync(int id)
        {
            var information = await _context.Informations.FindAsync(id);
            if (information == null) return null;

            return new InformationVM
            {
                Id = information.Id,
                
                Title = information.Title,
                Description = information.Description
            };
        }

        public async Task CreateAsync(InformationVM informationVM)
        {
            var information = new Information
            {
                
                Title = informationVM.Title,
                Description = informationVM.Description
            };

            _context.Informations.Add(information);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InformationVM informationVM)
        {
            var information = await _context.Informations.FindAsync(informationVM.Id);
            if (information != null)
            {
                information.Title = informationVM.Title;
                information.Description = informationVM.Description;
                

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var information = await _context.Informations.FindAsync(id);
            if (information != null)
            {
                _context.Informations.Remove(information);
                await _context.SaveChangesAsync();
            }
        }

    }
}
