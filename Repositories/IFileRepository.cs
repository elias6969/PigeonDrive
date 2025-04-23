namespace PigeonDrive.Api.Repositories
{
    using System.Threading.Tasks;
    using PigeonDrive.Api.Models;

    public interface IFileRepository
    {
        Task<FileItem> AddAsync(FileItem file);
        Task<FileItem?> GetByIdAsync(int id, string ownerId);
        Task DeleteAsync(FileItem file);
    }
}
