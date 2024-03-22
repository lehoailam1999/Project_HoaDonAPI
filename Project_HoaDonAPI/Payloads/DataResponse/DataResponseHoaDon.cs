using Project_HoaDonAPI.Entities;

namespace Project_HoaDonAPI.Payloads.DataResponse
{
    public class DataResponseHoaDon
    {
        public string TenKhachHang { get; set; }
        public string TenHoaDon { get; set; } 
        public string? MaGiaoDich { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public DateTime ThoiGianCapNhat { get; set; }
        public string GhiChu { get; set; }
        public string HinhAnh { get; set; }
        public double? TongTien { get; set; }
        public IQueryable<DataResponseChiTiet>? dataResponseChiTiets { get; set; }
    }
}
