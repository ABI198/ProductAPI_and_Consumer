using ABISoft.WebAPI1.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.WebAPI1.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetAllWithProducts(int id)
        {
            var categories = await _categoryRepository.GetAllWithProductsAsync();
            var selectedCategory = categories.SingleOrDefault(c => c.Id == id);
            if (selectedCategory != null)
                return Ok(selectedCategory);
            return NotFound(id);
        }
    }
}
