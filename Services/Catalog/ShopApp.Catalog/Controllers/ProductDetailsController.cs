using Microsoft.AspNetCore.Mvc;
using ShopApp.Catalog.Dtos.ProductDetailsDtos;
using ShopApp.Catalog.Services.ProductDetailService;

namespace ShopApp.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailsService;

        public ProductDetailsController(IProductDetailService productDetailsService)
        {
            _productDetailsService = productDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _productDetailsService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailsById(string id)
        {
            var value = await _productDetailsService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetails(CreateProductDetailDto createProductDetailsDto)
        {
            await _productDetailsService.CreateProductDetailAsync(createProductDetailsDto);
            return Ok("ProductDetails created successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetails(string id)
        {
            await _productDetailsService.DeleteProductDetailAsync(id);
            return Ok("ProductDetails delete successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetails(UpdateProductDetailDto updateProductDetailsDto)
        {
            await _productDetailsService.UpdateProductDetailAsync(updateProductDetailsDto);
            return Ok("ProductDetails updated successfully");
        }
    }
}
