using Project_HoaDonAPI.DataContext;
using Project_HoaDonAPI.Entities;
using Project_HoaDonAPI.Payloads.DataResponse;

namespace Project_HoaDonAPI.Payloads.Converters
{
    public class ChiTietHoaDonConverter
    {
        private readonly AppDbContext _context;
        public ChiTietHoaDonConverter()
        {
            _context = new AppDbContext();
        }
        public DataResponseChiTiet EntityToDTO(ChiTietHoaDon cthd)
        {
            return new DataResponseChiTiet()
            {
                DonViTinh = cthd.DonViTinh,
                SoLuong = cthd.SoLuong,
                TenSanPham = _context.SanPhams.SingleOrDefault(x => x.Id == cthd.SanPhamId).TenSanPham,
                ThanhTien = cthd.ThanhTien,
            };
        }
    }
}
