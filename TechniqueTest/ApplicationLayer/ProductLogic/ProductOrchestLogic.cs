using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs;
using DomainLayer.Entities;
using InfrastructureLayer.ProductRepository;

namespace ApplicationLayer.ProductLogic
{
    public class ProductOrchestLogic
    {
        private readonly IProductRepository _productRepository;
        public ProductOrchestLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<responseProductsDTO>> getAllProducts() => await _productRepository.getAllProductAsync();
        public async Task<responseGetUserToUpdateDTO> getUserToUpdate(int id) => await _productRepository.findProductToUpdate(id);
        public async Task<bool> createProductAsync(ProductDTO product)
        {
            try
            {
                var newProduct = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    QuantityStock = product.Quantity,
                    ProductTypeId = product.productTypeId,
                    ProductStatusId = 1
                };
                await _productRepository.createProductAsync(newProduct);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> updateProductAsync(ProductDTO product)
        {
            try
            {
                var productResult = await _productRepository.getProductById((int)product.Id);
                if (productResult is null) return false;
                productResult.Name = product.Name;
                productResult.Description = product.Description;
                productResult.Price = product.Price;
                productResult.QuantityStock = product.Quantity;
                productResult.ProductStatusId = (int)product.productStatusId;
                productResult.ProductTypeId = product.productTypeId;

                await _productRepository.UpdateProductAsync(productResult);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> deleteProductAsync(int id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
