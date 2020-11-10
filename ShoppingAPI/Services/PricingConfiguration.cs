using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Services
{
    public class PricingConfiguration
    {
        public readonly string SectionName = "Pricing";
        public decimal MarkUp { get; set; }
    }
}
