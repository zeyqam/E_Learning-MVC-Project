﻿using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.About;
using E_Learning_MVC_Project.ViewModels.Categories;
using E_Learning_MVC_Project.ViewModels.Information;
using E_Learning_MVC_Project.ViewModels.Instructor;
using E_Learning_MVC_Project.ViewModels.InstructorSocial;
using E_Learning_MVC_Project.ViewModels.Social;
using E_Learning_MVC_Project.ViewModels.Testimonial;

namespace E_Learning_MVC_Project.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<InformationVM> Informations { get; set; }
        public IEnumerable<AboutVM> Abouts { get; set; }
        public List<TestimonialVM> Testimonials { get; set; }
        public IEnumerable<InstructorVM> Instructors { get; set; }
        public List<InstructorSocialVM> Socials { get; set; }
        public IEnumerable<CategoryVM> Categories { get; set; }


        public string UserFullName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
