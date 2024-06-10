using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Social;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Learning_MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialController : Controller
    {

        private readonly ISocialService _socialService;
        private readonly IInstructorService _instructorService;

        public SocialController(ISocialService socialService, IInstructorService instructorService)
        {
            _socialService = socialService;
            _instructorService = instructorService;
        }

        public async Task<IActionResult> Index()
        {
            var socials = await _socialService.GetAllAsync();
            return View(socials);
        }

        public async Task<IActionResult> Create()
        {
            var instructors = await _instructorService.GetAllAsync();
            var viewModel = new SocialVM
            {
                Instructors = instructors.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = $"{i.Name} ({i.Designation})"
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SocialVM model)
        {
            if (ModelState.IsValid)
            {
                var social = new Social
                {
                    Name = model.Name,
                    Url = model.Url,
                    InstructorSocials = model.InstructorIds.Select(id => new InstructorSocial
                    {
                        InstructorId = id
                    }).ToList()
                };

                await _socialService.CreateAsync(social);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var social = await _socialService.GetByIdAsync(id);
            if (social == null)
            {
                return NotFound();
            }

            var instructors = await _instructorService.GetAllAsync();
            var viewModel = new SocialVM
            {
                Id = social.Id,
                Name = social.Name,
                Url = social.Url,
                InstructorIds = social.InstructorSocials.Select(m => m.InstructorId).ToList(),
                Instructors = instructors.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = $"{i.Name} ({i.Designation})"
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SocialVM model)
        {
            if (ModelState.IsValid)
            {
                var social = await _socialService.GetByIdAsync(model.Id);
                if (social == null)
                {
                    return NotFound();
                }

                social.Name = model.Name;
                social.Url = model.Url;
                social.InstructorSocials = model.InstructorIds.Select(id => new InstructorSocial
                {
                    InstructorId = id,
                    SocialId = social.Id
                }).ToList();

                await _socialService.UpdateAsync(social);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var social = await _socialService.GetByIdAsync(id);
            if (social == null)
            {
                return NotFound();
            }
            return View(social);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _socialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
       
}
