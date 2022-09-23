using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.Consume.Mvc.Models
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImagePath { get; set; }
        public int? CategoryId { get; set; } //FK
    }
}
