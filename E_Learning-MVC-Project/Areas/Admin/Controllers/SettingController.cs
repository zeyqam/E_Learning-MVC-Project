using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Setting;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            var settings = await _settingService.GetAllAsync();
            return View(settings);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var setting = await _settingService.GetByKeyAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            var model = new SettingEditVM
            {
                Key = setting.Key,
                Value = setting.Value
            };

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SettingEditVM request)
        {
            if (id != request.Key)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _settingService.UpdateAsync(request.Key, request.Value);
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }
    }



}
