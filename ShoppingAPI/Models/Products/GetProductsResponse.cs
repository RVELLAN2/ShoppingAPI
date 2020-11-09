using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Models.Products
{
    public class GetProductsResponse
    {
        public int NumberOfProductsInInvetory { get; set; }
        public int NumberOfProductsAddedToday { get; set; }
        public int NumberOfProductsOutOfStock { get; set; }

    }
}
