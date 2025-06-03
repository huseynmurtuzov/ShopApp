using Microsoft.AspNetCore.Mvc;
using ShopApp.Catalog.Dtos.ProductImageDtos;
using ShopApp.Catalog.Services.ProductImageService;

namespace ShopApp.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImagesService;

        public ProductImagesController(IProductImageService ProductImagesService)
        {
            _productImagesService = ProductImagesService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImagesList()
        {
            var values = await _productImagesService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImagesById(string id)
        {
            var value = await _productImagesService.GetByIdProductImageAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImages(CreateProductImageDto createProductImagesDto)
        {
            await _productImagesService.CreateProductImageAsync(createProductImagesDto);
            return Ok("ProductImages created successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImages(string id)
        {
            await _productImagesService.DeleteProductImageAsync(id);
            return Ok("ProductImages delete successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImages(UpdateProductImageDto updateProductImagesDto)
        {
            await _productImagesService.UpdateProductImageAsync(updateProductImagesDto);
            return Ok("ProductImages updated successfully");
        }
    }
}
