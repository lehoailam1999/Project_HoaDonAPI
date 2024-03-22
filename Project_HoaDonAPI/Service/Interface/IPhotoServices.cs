namespace Project_HoaDonAPI.Service.Interface
{
    public interface IPhotoServices
    {
        Task<string> UploadPhotoAsync(IFormFile file);
    }
}
