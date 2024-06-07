namespace E_Learning_MVC_Project.Services.Interface
{
    public interface ISettingService
    {
        Task<Dictionary<string, string>> GetAllAsync();

    }
}
