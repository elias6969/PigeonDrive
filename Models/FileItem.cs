namespace PigeonDrive.Api.Models
{
    public class FileItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Content { get; set; } = null!;
        public int FolderId { get; set; }
        public Folder Folder { get; set; } = null!;
    }
}
