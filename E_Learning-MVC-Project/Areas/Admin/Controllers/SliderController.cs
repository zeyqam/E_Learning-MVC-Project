using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetSlidersAsync();
            return View(sliders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _sliderService.CreateSliderAsync(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                await _sliderService.DeleteSliderAsync(id.Value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var slider = await _sliderService.GetSliderForEditAsync(id.Value);
                return View(slider);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderEditVM request)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                await _sliderService.EditSliderAsync(id.Value, request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(request);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
