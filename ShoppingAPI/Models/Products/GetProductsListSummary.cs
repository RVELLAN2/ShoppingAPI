using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ShoppingAPI.Models.Products
{
    public class GetProductsListSummary
    {
        public string Category { get; set; }
        public int Count { get; set; }
        public List<ProductSummaryItem> Data { get; set; }
    }
}
