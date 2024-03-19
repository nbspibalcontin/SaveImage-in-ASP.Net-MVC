using System.ComponentModel.DataAnnotations;

namespace SaveImage.Entity
{
    public class Image
    {
        [Key]
        public Guid ImageId {  get; set; }
        public string? ImageName { get; set; }
        public byte[]? ImageData { get; set; }
    }
}
