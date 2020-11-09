using ShoppingAPI.Models.Products;
using System.Threading.Tasks;

namespace ShoppingAPI
{
    public interface IProductCommands
    {
        Task<GetProductDetailsResponse> AddProduct(PostProductRequest productToAdd);
    }
}