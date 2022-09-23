using ABISoft.WebAPI1.Data;
using ABISoft.WebAPI1.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.WebAPI1.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _productRepository.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _productRepository.GetByIdAsync(id);
            if (data == null)
                return NotFound(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var addedProduct = await _productRepository.CreateAsync(product);
            return Created(string.Empty, addedProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var selectedProduct = await _productRepository.GetByIdAsync(product.Id);
            if (selectedProduct == null)
                return NotFound(product.Id);
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var selectedProduct = await _productRepository.GetByIdAsync(id);
            if (selectedProduct == null)
                NotFound(id);
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("upload")] //api/products/upload
        public async Task<IActionResult> Upload([FromForm]IFormFile formFile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty, formFile);
        }

        [HttpPost("[action]")] //api/products/action
        public IActionResult Test([FromHeader] string auth)
        {
            var authentication = HttpContext.Request.Headers["auth"];
            return Ok();
        }
    }
}
