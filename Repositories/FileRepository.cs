namespace PigeonDrive.Api.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using PigeonDrive.Api.Data;
    using PigeonDrive.Api.Models;

    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _db;
        public FileRepository(AppDbContext db) => _db = db;

        public async Task<FileItem> AddAsync(FileItem file)
        {
            _db.Files.Add(file);
            await _db.SaveChangesAsync();
            return file;
        }

        public async Task<FileItem?> GetByIdAsync(int id, string ownerId) =>
            await _db.Files
                     .Include(f => f.Folder)
                     .FirstOrDefaultAsync(f => f.Id == id && f.Folder.OwnerId == ownerId);

        public async Task DeleteAsync(FileItem file)
        {
            _db.Files.Remove(file);
            await _db.SaveChangesAsync();
        }
    }
}
