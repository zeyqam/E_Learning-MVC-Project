using E_Learning_MVC_Project.Services;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.About;
using E_Learning_MVC_Project.ViewModels.Testimonial;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            IEnumerable<TestimonialVM> testimonials = await _testimonialService.GetAllAsync();
            return View(testimonials);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(TestimonialCreateVM request)
        {
            if (ModelState.IsValid)
            {
                await _testimonialService.CreateAsync(request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);

            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _testimonialService.GetForEditAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, TestimonialEditVM model)
        {
            if (ModelState.IsValid)
            {
                await _testimonialService.EditAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _testimonialService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        private async Task<bool> TestimonilExists(int id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            return testimonial != null;
        }

    }
            
}
