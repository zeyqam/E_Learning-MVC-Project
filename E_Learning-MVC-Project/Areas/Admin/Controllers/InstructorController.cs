using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Instructor;
using E_Learning_MVC_Project.ViewModels.InstructorSocial;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;
        private readonly IInstructorSocialService _instructorSocialService;

        public InstructorController(IInstructorService instructorService, IInstructorSocialService instructorSocialService)
        {
            _instructorService = instructorService;
            _instructorSocialService = instructorSocialService;
        }

        public async Task<IActionResult> Index()
        {
            var socials = await _instructorSocialService.GetAllAsync();
            var socialVMs = socials.Select(s => new InstructorSocialVM
            {
                Id = s.Id,
                Name = s.Social.Name,
                Url = s.Social.Url,
                InstructorId = s.InstructorId
            }).ToList(); 

            return View(socialVMs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructorCreateVM request)
        {
            if (ModelState.IsValid)
            {
                await _instructorService.CreateAsync(request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var instructor = await _instructorService.GetForEditAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InstructorEditVM request)
        {
            if (ModelState.IsValid)
            {
                await _instructorService.EditAsync(id, request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var instructor = await _instructorService.GetForEditAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _instructorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
        
}
