namespace PigeonDrive.Api.Models.File
{
    public class CreateFileDto
    {
        public string Name { get; set; } = null!;
        public int FolderId { get; set; }
        public string Base64Content { get; set; } = null!;
    }
}
