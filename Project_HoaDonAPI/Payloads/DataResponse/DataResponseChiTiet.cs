using Project_HoaDonAPI.Entities;

namespace Project_HoaDonAPI.Payloads.DataResponse
{
    public class DataResponseChiTiet
    {
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public double? ThanhTien { get; set; }
    }
}
