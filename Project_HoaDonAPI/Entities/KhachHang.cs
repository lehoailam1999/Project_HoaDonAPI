using System.ComponentModel.DataAnnotations.Schema;

namespace Project_HoaDonAPI.Entities
{
    [Table("KhachHang_tbl")]
    public class KhachHang
    {
        public int Id { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string HinhAnh { get; set; }

        public IEnumerable<HoaDon> HoaDon { get; set; }
    }
}
