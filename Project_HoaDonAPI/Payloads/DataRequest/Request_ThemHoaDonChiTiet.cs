using Project_HoaDonAPI.Entities;

namespace Project_HoaDonAPI.Payloads.DataRequest
{
    public class Request_ThemHoaDonChiTiet
    {
        public int SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
    }
}
