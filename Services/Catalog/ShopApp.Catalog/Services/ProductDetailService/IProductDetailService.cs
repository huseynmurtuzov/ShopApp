﻿using ShopApp.Catalog.Dtos.ProductDetailsDtos;
using ShopApp.Catalog.Dtos.ProductDtos;

namespace ShopApp.Catalog.Services.ProductDetailService
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
