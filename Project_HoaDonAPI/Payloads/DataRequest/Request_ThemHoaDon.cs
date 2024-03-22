using Project_HoaDonAPI.Entities;

namespace Project_HoaDonAPI.Payloads.DataRequest
{
    public class Request_ThemHoaDon
    {
        public int KhachHangId { get; set; }
        public string TenHoaDon { get; set; }
        public string GhiChu { get; set; }
        public IFormFile HinhAnh { get; set; }

        public List<Request_ThemHoaDonChiTiet> themHoaDonChiTiets { get;set; }

    }
}
