using System.ComponentModel.DataAnnotations;

namespace SaveImage.DTOs.Request
{
    public class ImageDto
    {
        [Required(ErrorMessage = "Image name is required")]
        public string? ImageName { get; set; }

        [Required(ErrorMessage = "Image data is required")]
        public byte[]? ImageData { get; set; }

        public IFormFile? imageFile { get; set; }
    }
}
