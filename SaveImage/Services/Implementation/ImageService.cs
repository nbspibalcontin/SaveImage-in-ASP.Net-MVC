using Microsoft.EntityFrameworkCore;
using SaveImage.Data;
using SaveImage.DTOs.Request;
using SaveImage.DTOs.Response;
using SaveImage.Entity;
using SaveImage.Services.Interface;

namespace SaveImage.Services.Implementation
{
    public class ImageService : IIMage
    {
        private readonly ImageDbContext _dbContext;

        public ImageService(ImageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MessageResponse> AddImage(ImageDto imageDto, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imageFile.CopyToAsync(memoryStream);
                        imageDto.ImageData = memoryStream.ToArray();
                    }

                    var image = new Image
                    {
                        ImageName = imageDto.ImageName,
                        ImageData = imageDto.ImageData
                    };

                    _dbContext.Images.Add(image);
                    await _dbContext.SaveChangesAsync();

                    return new MessageResponse("Image Saved Successfully!");
                }
                else
                {
                    throw new ArgumentException("Image file is null or empty.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error when creating Image." + ex);
            }
        }

        public async Task<byte[]> GetImageData(string id)
        {
            try
            {
                // Convert string ID to GUID
                if (!Guid.TryParse(id, out Guid imageId))
                {
                    throw new ArgumentException("Invalid image ID format.");
                }

                var imageData = await _dbContext.Images
                                                 .Where(x => x.ImageId == imageId)
                                                 .Select(x => x.ImageData)
                                                 .FirstOrDefaultAsync();

                return imageData;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error when displaying the image." + ex);
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
