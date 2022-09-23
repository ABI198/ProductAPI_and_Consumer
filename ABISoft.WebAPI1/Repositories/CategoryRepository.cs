using ABISoft.WebAPI1.Data;
using ABISoft.WebAPI1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.WebAPI1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _context;
        public CategoryRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllWithProductsAsync()
        {
            var categories = await _context.Categories.Include(x => x.Products).ToListAsync();
            if (categories != null)
                return categories;
            return new List<Category>();
        }
    }
}
