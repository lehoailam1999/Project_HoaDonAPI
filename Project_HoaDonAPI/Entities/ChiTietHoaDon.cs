using System.ComponentModel.DataAnnotations.Schema;

namespace Project_HoaDonAPI.Entities
{
    [Table("ChiTietHoaDon_tbl")]
    public class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int? HoaDonId { get; set; }
        public int SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public double? ThanhTien { get; set; }
        public HoaDon? HoaDon { get; set; }
        public KhachHang? KhachHang { get; set; }
    }
}
