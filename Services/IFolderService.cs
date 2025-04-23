namespace PigeonDrive.Api.Services
{
    using System.Threading.Tasks;
    using PigeonDrive.Api.Models;

    /// <summary>
    /// Manages folder operations.
    /// </summary>
    public interface IFolderService
    {
        /// <summary>
        /// Creates a new folder for the specified user.
        /// </summary>
        Task<Folder> CreateFolderAsync(string name, string userId);

        /// <summary>
        /// Retrieves a folder by ID if owned by the user.
        /// </summary>
        Task<Folder?> GetFolderByIdAsync(int id, string userId);

        /// <summary>
        /// Deletes a folder by ID for the specified user.
        /// </summary>
        Task<bool> DeleteFolderAsync(int folderId, string userId);
    }
}
