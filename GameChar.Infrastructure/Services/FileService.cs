using GameChar.Application.Abstractions.Services;

namespace GameChar.Infrastructure.Services;

public class FileService : IFileService
{
    public async Task SaveFileAsync(string filePath, byte[] content)
    {
        await File.WriteAllBytesAsync(filePath, content);
    }

    public async Task<byte[]> ReadFileAsync(string filePath)
    {
        return await File.ReadAllBytesAsync(filePath);
    }
}
