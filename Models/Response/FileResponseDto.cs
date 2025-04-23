namespace PigeonDrive.Api.Models.Response
{
    public class FileResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int FolderId { get; set; }
    }
}
