﻿using ShopApp.Catalog.Dtos.CategoryDtos;
using ShopApp.Catalog.Dtos.ProductDtos;

namespace ShopApp.Catalog.Services.ProductService
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
