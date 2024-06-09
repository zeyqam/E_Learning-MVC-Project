
using E_Learning_MVC_Project.Services;
using E_Learning_MVC_Project.Services.Interface;
using E_Learning_MVC_Project.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Learning_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInformationService _informationService;
        public HomeController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        public async Task< IActionResult> Index()
        {
            HomeVM model = new()
            {

                Informations = await _informationService.GetAllAsync(),
                
            };





            return View(model);
        }
        
    }

}