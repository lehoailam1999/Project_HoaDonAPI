using System.ComponentModel.DataAnnotations.Schema;

namespace Project_HoaDonAPI.Entities
{
    [Table("SanPham_tbl")]
    public class LoaiSanPham
    {
        public int Id { get; set; }
        public string TenLoaiSanPham { get; set; }
        public IEnumerable<SanPham> SanPham { get; set; }
    }
}
