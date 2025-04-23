namespace PigeonDrive.Api.Services
{
    using System.Threading.Tasks;
    using PigeonDrive.Api.Models;
    using PigeonDrive.Api.Repositories;

    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _repo;
        public FolderService(IFolderRepository repo) => _repo = repo;

        /// <summary>
        /// Creates a folder for a specific user.
        /// </summary>
        /// <param name="name">The name of the folder.</param>
        /// <param name="userId">The ID of the user who owns the folder.</param>
        /// <returns>The created folder object.</returns>
        public async Task<Folder> CreateFolderAsync(string name, string userId)
        {
            var folder = new Folder { Name = name, OwnerId = userId };
            await _repo.AddAsync(folder);
            return folder;
        }

        /// <summary>
        /// Retrieves a folder by ID for a specific user.
        /// </summary>
        /// <param name="id">The ID of the folder to retrieve.</param>
        /// <param name="userId">The ID of the user requesting the folder.</param>
        /// <returns>The folder if found, or null if not found or unauthorized.</returns>
        public Task<Folder?> GetFolderByIdAsync(int id, string userId) =>
            _repo.GetByIdAsync(id, userId);

        /// <summary>
        /// Deletes a folder if it belongs to the user.
        /// </summary>
        /// <param name="folderId">The ID of the folder to delete.</param>
        /// <param name="userId">The ID of the user attempting the deletion.</param>
        /// <returns>True if deleted successfully, false if not found or unauthorized.</returns>
        public async Task<bool> DeleteFolderAsync(int folderId, string userId)
        {
            var folder = await _repo.GetByIdAsync(folderId, userId);
            if (folder == null) return false;
            await _repo.DeleteAsync(folder);
            return true;
        }
    }
}
