using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Models.Products
{
    public class PostProductRequest
    {
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string Category { get; set; }
        [Required]
        public decimal? UnitPrice { get; set; }
    }
}
