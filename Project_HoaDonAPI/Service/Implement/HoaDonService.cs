using Project_HoaDonAPI.DataContext;
using Project_HoaDonAPI.Entities;
using Project_HoaDonAPI.Payloads.Converters;
using Project_HoaDonAPI.Payloads.DataRequest;
using Project_HoaDonAPI.Payloads.DataResponse;
using Project_HoaDonAPI.Payloads.Response;
using Project_HoaDonAPI.Service.Interface;
using System.Web.Http.ModelBinding;

namespace Project_HoaDonAPI.Service.Implement
{
    public class HoaDonService:IHoaDonService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseHoaDon> _responseObject;
        private readonly IPhotoServices _photoServices;
        private readonly HoaDonConverter _converter;

        public HoaDonService(ResponseObject<DataResponseHoaDon> responseObject, HoaDonConverter converter, IPhotoServices photoServices)
        {
            _context = new AppDbContext();
            _responseObject = responseObject;
            _converter = converter;
            _photoServices = photoServices;
        }

        public  async Task<ResponseObject<DataResponseHoaDon>> ThemHoaDon(Request_ThemHoaDon request)
        {
           

            var khachang = _context.KhachHangs.SingleOrDefault(x=>x.Id==request.KhachHangId);
            if (khachang is null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay khach hang", null); ;
            }
            HoaDon hoadon = new HoaDon();
            hoadon.TenHoaDon = request.TenHoaDon;
            hoadon.KhachHangId = request.KhachHangId;
            hoadon.MaGiaoDich = new Random().Next(100000,999999).ToString();
            hoadon.ThoiGianCapNhat = DateTime.Now;
            hoadon.ThoiGianTao = DateTime.Now;
            hoadon.GhiChu = request.GhiChu;
            hoadon.TongTien = 0;
            hoadon.HinhAnh = "";
            hoadon.ChiTietHoaDon = null;
            _context.HoaDons.Add(hoadon);
            await _context.SaveChangesAsync();
            //Thêm chi tiết hóa đơn vào hóa đơn
             hoadon.ChiTietHoaDon = await  ThemListChiTiet(hoadon.Id, request.themHoaDonChiTiets);
            _context.HoaDons.Update(hoadon);
             await  _context.SaveChangesAsync();
            double? tongTien = 0;
            foreach (var item in hoadon.ChiTietHoaDon)
            {
                tongTien += item.ThanhTien; 
            }
            hoadon.TongTien = tongTien;
            _context.HoaDons.Update(hoadon);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Thêm hóa đơn thành công", _converter.EntityToDTO(hoadon));

        }
        private async Task<List<ChiTietHoaDon>> ThemListChiTiet(int hoadonId,List<Request_ThemHoaDonChiTiet> requests)
        {
           /* var hoadon =  _context.HoaDons.SingleOrDefault(x => x.Id == hoadonId);
            if (hoadon is null)
            {
                return null;
            }*/
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            foreach (var request in requests)
            {
                ChiTietHoaDon ct = new ChiTietHoaDon();
                var sanpham = _context.SanPhams.SingleOrDefault(x => x.Id == request.SanPhamId);
                if (sanpham is null)
                {
                    throw new Exception("San pham khong ton tai");
                }
                ct.HoaDonId = hoadonId;
                ct.SanPhamId = request.SanPhamId;
                ct.DonViTinh = request.DonViTinh;
                ct.SoLuong = request.SoLuong;
                ct.ThanhTien = sanpham.GiaThan * request.SoLuong;
                list.Add(ct);
            }
             await _context.ChiTietHoaDons.AddRangeAsync(list);
             await _context.SaveChangesAsync();
            return list;
        }
    }
}
