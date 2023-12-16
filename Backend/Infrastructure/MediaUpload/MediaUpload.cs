using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.MediaUpload
{
    public class MediaUpload : IMediaUpload
    {
        private readonly Cloudinary cloudinary;

        public MediaUpload(IOptions<CloudinarySettings> config)
        {
            Account account = new Account(config.Value.CloudName,config.Value.ApiKey,config.Value.ApiSecret);
            cloudinary = new Cloudinary(account);
        }

        public string UploadImage(IFormFile file)
        {
            ImageUploadResult uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (Stream stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = cloudinary.Upload(uploadParams);
                }
            }

            if (uploadResult.Error != null)
            {
                throw new Exception(uploadResult.Error.Message);
            }

            return uploadResult.SecureUrl.AbsoluteUri;
        }
    }
}
