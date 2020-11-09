using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models.Products;

namespace ShoppingAPI.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly ILookupProducts _products;

        public ProductsController(ILookupProducts products)
        {
            _products = products;
        }

        [HttpGet("products")]
        public async Task<ActionResult> GetProducts([FromQuery] string category = null)
        {
            if (category == null)
            {
                GetProductsResponse response = await _products.GetSummary();
                return Ok(response);
            }
            else
            {
                GetProductsListSummary response = await _products.GetSummaryList(category);
                return Ok(response);
            }
        }
    }
}
