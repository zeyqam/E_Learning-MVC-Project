using E_Learning_MVC_Project.ViewModels.About;
using E_Learning_MVC_Project.ViewModels.Information;
using E_Learning_MVC_Project.ViewModels.Testimonial;

namespace E_Learning_MVC_Project.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<InformationVM> Informations { get; set; }
        public IEnumerable<AboutVM> Abouts { get; set; }
        public List<TestimonialVM> Testimonials { get; set; }
    }
}
