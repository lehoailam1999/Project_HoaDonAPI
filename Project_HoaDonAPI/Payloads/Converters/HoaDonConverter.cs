using Project_HoaDonAPI.DataContext;
using Project_HoaDonAPI.Entities;
using Project_HoaDonAPI.Payloads.DataResponse;

namespace Project_HoaDonAPI.Payloads.Converters
{
    public class HoaDonConverter
    {
        private readonly AppDbContext _context;
        private readonly ChiTietHoaDonConverter _converter;
        public HoaDonConverter()
        {
            _context = new AppDbContext();
            _converter = new ChiTietHoaDonConverter();
        }
        //public DataResponseHoaDon EntityToDTO(HoaDon hoadon)
        //{
            
        //    return new DataResponseHoaDon()
        //    {
        //        TenKhachHang = _context.KhachHangs.SingleOrDefault(x => x.Id == hoadon.Id).TenKhachHang,
        //        TenHoaDon = hoadon.TenHoaDon,
        //        GhiChu = hoadon.GhiChu,
        //        MaGiaoDich = hoadon.MaGiaoDich,
        //        ThoiGianTao = hoadon.ThoiGianTao,
        //        ThoiGianCapNhat = hoadon.ThoiGianCapNhat,
        //        TongTien = hoadon.TongTien,
        //        dataResponseChiTiets = _context.ChiTietHoaDons.Where(x => x.HoaDonId == hoadon.Id)
        //                            .Select(x => _converter.EntityToDTO(x))
        //    };
        //}
        public DataResponseHoaDon EntityToDTO(HoaDon hoadon)
        {
            DataResponseHoaDon response = new DataResponseHoaDon()
            {
                TenHoaDon = hoadon.TenHoaDon,
                GhiChu = hoadon.GhiChu,
                MaGiaoDich = hoadon.MaGiaoDich,
                ThoiGianTao = hoadon.ThoiGianTao,
                ThoiGianCapNhat = hoadon.ThoiGianCapNhat,
                TongTien = hoadon.TongTien,
                HinhAnh=hoadon.HinhAnh
                
            };

            if (hoadon.Id != null)
            {
                KhachHang khachHang = _context.KhachHangs.SingleOrDefault(x => x.Id == hoadon.Id);
                if (khachHang != null)
                {
                    response.TenKhachHang = khachHang.TenKhachHang;
                }
            }

            if (hoadon.Id != null)
            {
                var chiTietHoaDons = _context.ChiTietHoaDons.Where(x => x.HoaDonId == hoadon.Id);
                if (chiTietHoaDons != null)
                {
                    response.dataResponseChiTiets = chiTietHoaDons.Select(x => _converter.EntityToDTO(x));
                }
            }

            return response;
        }

    }
}
