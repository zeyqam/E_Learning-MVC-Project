using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialController : Controller
    {
        private readonly ISocialService _socialService;

        public SocialController(ISocialService socialService)
        {
            _socialService = socialService;
        }
        public async Task< IActionResult> Index()
        {
            var socials = await _socialService.GetAllAsync();
            return View(socials);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Social social)
        {
            if (ModelState.IsValid)
            {
                await _socialService.CreateAsync(social);
                return RedirectToAction(nameof(Index));
            }
            return View(social);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var social = await _socialService.GetByIdAsync(id);
            if (social == null)
            {
                return NotFound();
            }
            return View(social);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Social social)
        {
            if (ModelState.IsValid)
            {
                await _socialService.UpdateAsync(social);
                return RedirectToAction(nameof(Index));
            }
            return View(social);
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
