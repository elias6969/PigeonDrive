namespace PigeonDrive.Api.Models
{
    using System.Collections.Generic;

    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
        public ApplicationUser Owner { get; set; } = null!;
        public ICollection<FileItem> Files { get; set; } = new List<FileItem>();
    }
}
