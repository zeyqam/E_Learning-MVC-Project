using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_MVC_Project.ViewModels.Information
{
    public class InformationVM
    {
        public int Id { get; set; }

        
        

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}

