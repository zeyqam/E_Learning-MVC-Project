
using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.Services;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.About;
using E_Learning_MVC_Project.ViewModels.Home;
using E_Learning_MVC_Project.ViewModels.Instructor;
using E_Learning_MVC_Project.ViewModels.InstructorSocial;
using E_Learning_MVC_Project.ViewModels.Social;
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
        private readonly IInstructorService _instructorService;
        private readonly ISocialService _socialService;
        public HomeController(IInformationService informationService, 
                              IAboutService aboutService,
                              ITestimonialService testimonialService,
                              UserManager<AppUser> userManager,
                              IInstructorService instructorService,
                              ISocialService socialService)
        {
            _informationService = informationService;
            _aboutService = aboutService;
            _testimonialService = testimonialService;
            _userManager = userManager;
            _instructorService = instructorService;
            _socialService = socialService;
        }

        public async Task< IActionResult> Index()
        {
            var instructors = await _instructorService.GetAllAsync();

            var instructorVMs = instructors.Select(i => new InstructorVM
            {
                Id = i.Id,
                Name = i.Name,
                Designation = i.Designation,
                Image = i.Image,
                InstructorSocials = i.InstructorSocials.Select(s => new InstructorSocialVM
                {
                    Name = s.Social.Name,
                    Url = s.Social.Url
                }).ToList()
            }).ToList();

            var socials = await _socialService.GetAllAsync();
            var instructorSocialVMs = socials.Select(m => new InstructorSocialVM
            {
                Id = m.Id,
                
                Name=m.Social.Name,
                Url=m.Social.Url,
               
                InstructorId = m.InstructorId
            }).ToList();

            HomeVM model = new()
            {



                Informations = await _informationService.GetAllAsync(),
                Abouts = await _aboutService.GetAllAsync(),
                Testimonials = (List<ViewModels.Testimonial.TestimonialVM>)await _testimonialService.GetAllAsync(),
                Instructors = instructorVMs,
                Socials = instructorSocialVMs
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