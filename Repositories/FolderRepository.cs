namespace PigeonDrive.Api.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using PigeonDrive.Api.Data;
    using PigeonDrive.Api.Models;

    public class FolderRepository : IFolderRepository
    {
        private readonly AppDbContext _db;
        public FolderRepository(AppDbContext db) => _db = db;

        public async Task<Folder?> GetByIdAsync(int id, string ownerId) =>
            await _db.Folders.Include(f => f.Files)
                             .FirstOrDefaultAsync(f => f.Id == id && f.OwnerId == ownerId);

        public async Task AddAsync(Folder folder)
        {
            _db.Folders.Add(folder);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Folder folder)
        {
            _db.Folders.Remove(folder);
            await _db.SaveChangesAsync();
        }
    }
}
