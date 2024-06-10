using AutoMapper;
using E_Learning_MVC_Project.ViewModels.Social;

namespace E_Learning_MVC_Project.Models
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Social, SocialVM>().ReverseMap();
        }
    }
}
