namespace PigeonDrive.Api.Repositories
{
    using System.Threading.Tasks;
    using PigeonDrive.Api.Models;

    public interface IFolderRepository
    {
        Task<Folder?> GetByIdAsync(int id, string ownerId);
        Task AddAsync(Folder folder);
        Task DeleteAsync(Folder folder);
    }
}
