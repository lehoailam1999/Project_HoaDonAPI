namespace Project_HoaDonAPI.Entities
{
    public class SanPham
    {
        public int Id { get; set; }
        public int LoaiSanPhamId { get; set; }
        public string TenSanPham { get; set; }
        public double GiaThan { get; set; }
        public string Mota { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string KyHieuSanPham { get; set; }
        public IEnumerable<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }
    }
}
