namespace MedNow.Application.Contracts.Services
{
    public interface ICachingService
    {
        Task SetAsync(string key, object value);
        Task<string> GetAsync(string key);
    }
}
