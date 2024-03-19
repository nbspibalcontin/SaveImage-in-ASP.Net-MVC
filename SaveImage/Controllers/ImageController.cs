using Microsoft.AspNetCore.Mvc;
using SaveImage.DTOs.Request;
using SaveImage.Services.Implementation;
using SaveImage.Services.Interface;


namespace SaveImage.Controllers
{
    public class ImageController : Controller
    {
        private readonly IIMage ImageService;

        public ImageController(IIMage imageService)
        {
            ImageService = imageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(ImageDto imageDto, IFormFile imageFile)
        {
            try
            {
                var response = await ImageService.AddImage(imageDto, imageFile);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, ex.Message); // Internal Server Error
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex);
            }
        }

        public async Task<IActionResult> ShowImage(string id)
        {
            try
            {
                var imageData = await ImageService.GetImageData(id);
                return View(imageData);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, ex.Message); // Internal Server Error
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex);
            }
        }
    }
}
