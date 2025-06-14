using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities;
using DomainLayer.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.ProductRepository
{
    public class ProductRepository: IProductRepository
    {
        private readonly StoreDbContext _context;
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task createProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<responseProductsDTO>> getAllProductAsync()
        {
            return await _context.Product
                .Where(p => p.ProductStatusId == 1)
                .Select(p => new responseProductsDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    QuantityStock = p.QuantityStock,
                    ProductTypeName = p.ProductType.Name
                })
                .ToListAsync();
        }

        public async Task<responseGetUserToUpdateDTO> findProductToUpdate(int id)
        {
            return await _context.Product
                .Where(p => p.Id == id && p.ProductStatusId == 1)
                .Select(p => new responseGetUserToUpdateDTO
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.QuantityStock,
                    productTypeId = p.ProductTypeId,
                    productStatusId = p.ProductStatusId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Product?> getProductById(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await getProductById(id);
            if(product != null)
            {
                product.ProductStatusId = 2;
                await _context.SaveChangesAsync();
            }
        }
    }
}
