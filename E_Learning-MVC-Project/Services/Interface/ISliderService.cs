using E_Learning_MVC_Project.Models;
using E_Learning_MVC_Project.ViewModels.Slider;

namespace E_Learning_MVC_Project.Services.Interface
{
    public interface ISliderService
    {
        Task<IEnumerable<Slider>> GetAllAsync();
        Task<List<SliderVM>> GetSlidersAsync();
        Task CreateSliderAsync(SliderCreateVM request);
        Task DeleteSliderAsync(int id);
        Task<SliderEditVM> GetSliderForEditAsync(int id);
        Task EditSliderAsync(int id, SliderEditVM request);

    }
}
