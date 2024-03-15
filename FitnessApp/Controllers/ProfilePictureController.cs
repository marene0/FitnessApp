using FitnessApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class ProfilePictureController : Controller
    {
        [Authorize]
        public class FileManagerController : ControllerBase

        {

            private readonly IManageImage _iManageImage;
            public FileManagerController(IManageImage iManageImage)
            {
                _iManageImage = iManageImage;
            }

            [HttpPost("image")]

            public async Task<IActionResult> UploadFile(IFormFile _File, Guid userId)
            {
                var result = await _iManageImage.UploadFile(_File, userId);
                return Ok(result);
            }

            [HttpGet("{fileName}")]
            public async Task<IActionResult> DownloadFile(string fileName)
            {
                var result = await _iManageImage.DownloadFile(fileName);
                return File(result.Item1, result.Item2, result.Item2);
            }
        }

    }
}
