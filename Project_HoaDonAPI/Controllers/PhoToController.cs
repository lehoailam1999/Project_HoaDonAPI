using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_HoaDonAPI.Service.Interface;

namespace Project_HoaDonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoToController : ControllerBase
    {
        private readonly IPhotoServices _photoService;

        public PhoToController(IPhotoServices photoService)
        {
            _photoService = photoService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            var photoUrl = await _photoService.UploadPhotoAsync(file);
            return Ok(new { url = photoUrl });
        }
    }
}
