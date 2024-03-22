using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_HoaDonAPI.Payloads.DataRequest;
using Project_HoaDonAPI.Service.Interface;

namespace Project_HoaDonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonService _service;

        public HoaDonController(IHoaDonService service)
        {
            _service = service;
        }
        [HttpPost("ThemHoaDon")]
        public async Task<IActionResult> ThemHoaDon([FromForm]Request_ThemHoaDon request, IFormFile HinhAnh)
        {

            //var fileanh = _service.ThemHoaDon(file, request);
            return Ok(await _service.ThemHoaDon(request));
        }
    }
}
