
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Learning_MVC_Project.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        
    }

}