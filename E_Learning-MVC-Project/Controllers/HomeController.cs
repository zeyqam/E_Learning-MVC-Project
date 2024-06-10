
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.About;
using E_Learning_MVC_Project.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace E_Learning_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInformationService _informationService;
        private readonly IAboutService _aboutService;
        private readonly ITestimonialService _testimonialService;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(IInformationService informationService, 
                              IAboutService aboutService,
                              ITestimonialService testimonialService,
                              UserManager<AppUser> userManager)
        {
            _informationService = informationService;
            _aboutService = aboutService;
            _testimonialService = testimonialService;
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            
            HomeVM model = new()
            {

                Informations = await _informationService.GetAllAsync(),
                Abouts = await _aboutService.GetAllAsync(),
                Testimonials= (List<ViewModels.Testimonial.TestimonialVM>)await _testimonialService.GetAllAsync()
            };
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                model.UserFullName = user?.FullName;
                model.IsAuthenticated = true;
            }




            return View(model);
        }
        
    }

}