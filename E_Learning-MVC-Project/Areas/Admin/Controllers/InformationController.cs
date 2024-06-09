using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Information;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InformationController : Controller
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        public async Task<IActionResult> Index()
        {
            var informations = await _informationService.GetAllAsync();
            return View(informations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InformationVM informationVM)
        {
            if (!ModelState.IsValid) return View(informationVM);

            await _informationService.CreateAsync(informationVM);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var information = await _informationService.GetByIdAsync(id);
            if (information == null) return NotFound();

            return View(information);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InformationVM informationVM)
        {
            if (!ModelState.IsValid) return View(informationVM);

            await _informationService.UpdateAsync(informationVM);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var information = await _informationService.GetByIdAsync(id);
            if (information == null) return NotFound();

            return View(information);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _informationService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
