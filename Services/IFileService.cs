namespace PigeonDrive.Api.Services
{
    using System.Threading.Tasks;
    using PigeonDrive.Api.Models;

    public interface IFileService
    {
        /// <summary>
        /// Uploads a file to a specific folder for a user.
        /// </summary>
        /// <param name="name">The file name.</param>
        /// <param name="content">The file content as a byte array.</param>
        /// <param name="folderId">The ID of the folder to upload to.</param>
        /// <param name="userId">The ID of the user uploading the file.</param>
        /// <returns>The uploaded FileItem.</returns>
        Task<FileItem> UploadFileAsync(string name, byte[] content, int folderId, string userId);

        /// <summary>
        /// Downloads a file by ID if it belongs to the user.
        /// </summary>
        /// <param name="fileId">The ID of the file.</param>
        /// <param name="userId">The ID of the user requesting the file.</param>
        /// <returns>The file if found, or null.</returns>
        Task<FileItem?> DownloadFileAsync(int fileId, string userId);

        /// <summary>
        /// Deletes a file if it belongs to the user.
        /// </summary>
        /// <param name="fileId">The ID of the file to delete.</param>
        /// <param name="userId">The ID of the user attempting the deletion.</param>
        /// <returns>True if deleted successfully, false otherwise.</returns>
        Task<bool> DeleteFileAsync(int fileId, string userId);
    }
}
