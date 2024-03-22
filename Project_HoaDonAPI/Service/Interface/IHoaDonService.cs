using Project_HoaDonAPI.Payloads.DataRequest;
using Project_HoaDonAPI.Payloads.DataResponse;
using Project_HoaDonAPI.Payloads.Response;

namespace Project_HoaDonAPI.Service.Interface
{
    public interface IHoaDonService
    {
         Task<ResponseObject<DataResponseHoaDon>> ThemHoaDon(Request_ThemHoaDon request);
    }
}
