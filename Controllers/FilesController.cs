using PigeonDrive.Api.Models.Response;

namespace PigeonDrive.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PigeonDrive.Api.Models.File;
    using PigeonDrive.Api.Services;
    using System;
    using System.Security.Claims;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _svc;
        public FilesController(IFileService svc) => _svc = svc;

        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> Upload(CreateFileDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            byte[] content = Convert.FromBase64String(dto.Base64Content);
            var file = await _svc.UploadFileAsync(dto.Name, content, dto.FolderId, userId);

            // Map to response DTO
            var response = new FileResponseDto
            {
                Id = file.Id,
                Name = file.Name,
                FolderId = file.FolderId
            };

            // Return the DTO instead of the EF entity
            return CreatedAtAction(nameof(Download), new { id = response.Id }, response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var file = await _svc.DownloadFileAsync(id, userId);
            if (file == null) return NotFound();
            return File(file.Content, "application/octet-stream", file.Name);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (!await _svc.DeleteFileAsync(id, userId)) return NotFound();
            return NoContent();
        }
    }
}
