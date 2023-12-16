using Microsoft.AspNetCore.Http;

namespace Infrastructure.MediaUpload
{
    public interface IMediaUpload
    {
        string UploadImage(IFormFile file);
    }
}
