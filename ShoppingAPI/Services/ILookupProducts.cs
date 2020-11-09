using ShoppingAPI.Models.Products;
using System.Threading.Tasks;

namespace ShoppingAPI
{
    public interface ILookupProducts
    {
        Task<GetProductsResponse> GetSummary();
        Task<GetProductsListSummary> GetSummaryList(string category);
    }
}