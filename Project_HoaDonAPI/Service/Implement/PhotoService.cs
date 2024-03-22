using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Project_HoaDonAPI.Service.Interface;

namespace Project_HoaDonAPI.Service.Implement
{
    public class PhotoService : IPhotoServices
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IConfiguration configuration)
        {
            var account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]);

            _cloudinary = new Cloudinary(account);
        }
        public async Task<string> UploadPhotoAsync(IFormFile file)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Folder = "products"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.ToString(); 
        }
    }
}
