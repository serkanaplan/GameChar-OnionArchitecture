namespace GameChar.Application.Abstractions.Services;

public interface IExternalApiService
{
    Task<string> GetExternalDataAsync();
}
