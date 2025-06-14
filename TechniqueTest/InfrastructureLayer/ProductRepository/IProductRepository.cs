using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs;
using DomainLayer.Entities;

namespace InfrastructureLayer.ProductRepository
{
    public interface IProductRepository
    {
        Task createProductAsync(Product product);
        Task<IEnumerable<responseProductsDTO>> getAllProductAsync();
        Task<responseGetUserToUpdateDTO> findProductToUpdate (int  id);
        Task<Product?> getProductById (int id);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
