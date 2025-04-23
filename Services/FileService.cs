namespace PigeonDrive.Api.Services
{
    using System;
    using System.Threading.Tasks;
    using PigeonDrive.Api.Models;
    using PigeonDrive.Api.Repositories;

    public class FileService : IFileService
    {
        private readonly IFileRepository _repo;
        private readonly IFolderRepository _folderRepo;

        public FileService(IFileRepository repo, IFolderRepository folderRepo)
        {
            _repo = repo;
            _folderRepo = folderRepo;
        }

        /// <summary>
        /// Uploads a file to a specified folder if the user owns the folder.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <param name="content">The content of the file as a byte array.</param>
        /// <param name="folderId">The ID of the folder where the file will be stored.</param>
        /// <param name="userId">The ID of the user attempting the upload.</param>
        /// <returns>The created file item.</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown when the folder does not belong to the user.</exception>
        public async Task<FileItem> UploadFileAsync(string name, byte[] content, int folderId, string userId)
        {
            // Ensure folder belongs to user
            var folder = await _folderRepo.GetByIdAsync(folderId, userId);
            if (folder == null) throw new UnauthorizedAccessException();

            var file = new FileItem { Name = name, Content = content, FolderId = folderId };
            return await _repo.AddAsync(file);
        }

        /// <summary>
        /// Retrieves a file if it belongs to the specified user.
        /// </summary>
        /// <param name="fileId">The ID of the file to download.</param>
        /// <param name="userId">The ID of the user requesting the file.</param>
        /// <returns>The file item if found; otherwise, null.</returns>
        public Task<FileItem?> DownloadFileAsync(int fileId, string userId) =>
            _repo.GetByIdAsync(fileId, userId);

        /// <summary>
        /// Deletes a file if it belongs to the specified user.
        /// </summary>
        /// <param name="fileId">The ID of the file to delete.</param>
        /// <param name="userId">The ID of the user requesting deletion.</param>
        /// <returns>True if the file was deleted; otherwise, false.</returns>
        public async Task<bool> DeleteFileAsync(int fileId, string userId)
        {
            var file = await _repo.GetByIdAsync(fileId, userId);
            if (file == null) return false;
            await _repo.DeleteAsync(file);
            return true;
        }
    }
}
