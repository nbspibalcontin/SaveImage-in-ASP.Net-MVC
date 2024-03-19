using SaveImage.DTOs.Request;
using SaveImage.DTOs.Response;
using SaveImage.Entity;

namespace SaveImage.Services.Interface
{
    public interface IIMage : IDisposable
    {
        Task<MessageResponse> AddImage(ImageDto image, IFormFile imageFile);
        Task<byte[]> GetImageData(string id);
    }
}
