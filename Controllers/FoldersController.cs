namespace PigeonDrive.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PigeonDrive.Api.Models.Dtos;
    using PigeonDrive.Api.Services;
    using System.Security.Claims;
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FoldersController : ControllerBase
    {
        private readonly IFolderService _svc;
        public FoldersController(IFolderService svc) => _svc = svc;

        [HttpPost]
        public async Task<IActionResult> Create(CreateFolderDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var folder = await _svc.CreateFolderAsync(dto.Name, userId);
            return CreatedAtAction(nameof(Get), new { id = folder.Id }, folder);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var folder = await _svc.GetFolderByIdAsync(id, userId);
            if (folder == null) return NotFound();
            return Ok(folder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (!await _svc.DeleteFolderAsync(id, userId)) return NotFound();
            return NoContent();
        }
    }
}
