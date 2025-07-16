using DUPSS.Application.Abtractions;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    public class FilesController(IFileService fileService) : BaseAPIController
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var filePath = await fileService.UploadFileAsync(file);
            return Ok(new { FilePath = filePath });
        }

        [HttpGet]
        public async Task<IActionResult> LoadFile(string filePath)
        {
            var fileBytes = await fileService.LoadFileAsync(filePath);
            return File(fileBytes, "application/octet-stream", Path.GetFileName(filePath));
        }

        [HttpDelete]
        public IActionResult DeleteFile(string filePath)
        {
            fileService.DeleteFileAsync(filePath);
            return NoContent();
        }
    }
}
