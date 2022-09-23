using ABISoft.WebAPI1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.WebAPI1.Interfaces
{
    public interface ICategoryRepository
    {
       public Task<List<Category>> GetAllWithProductsAsync();
    }
}
