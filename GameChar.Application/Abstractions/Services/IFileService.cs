namespace GameChar.Application.Abstractions.Services;

public interface IFileService
{
    Task SaveFileAsync(string filePath, byte[] content);
    Task<byte[]> ReadFileAsync(string filePath);
}
