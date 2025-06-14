using Microsoft.AspNetCore.Mvc;
using DomainLayer.DTOs;
using ApplicationLayer.ProductLogic;

namespace TechniqueTest.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductOrchestLogic _productService;
        public ProductController(ProductOrchestLogic productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("create-product")]
        public async Task<IActionResult> createProduct([FromBody]ProductDTO product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _productService.createProductAsync(product));
        }

        [HttpGet]
        [Route("get-all-products")]
        public async Task<IActionResult> getProducts()
        {
            return Ok(await _productService.getAllProducts());
        }

        [HttpGet]
        [Route("get-product-to-update")]
        public async Task<IActionResult> getProduct(int productId)
        {
            return Ok(await _productService.getUserToUpdate(productId));
        }

        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> updateProduct([FromBody]ProductDTO product)
        {
            return Ok(await _productService.updateProductAsync(product));
        }

        [HttpDelete]
        [Route("delete-product")]
        public async Task<IActionResult> deleteProduct(int id)
        {
            return Ok(await _productService.deleteProductAsync(id));
        }
    }
}
