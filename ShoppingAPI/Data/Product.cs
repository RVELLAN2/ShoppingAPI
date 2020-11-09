using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public bool InInventory { get; set; }
        public string Category { get; set; }
    }
}
