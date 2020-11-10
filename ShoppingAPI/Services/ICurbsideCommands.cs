using ShoppingAPI.Models.Curbside;
using System.Threading.Tasks;

namespace ShoppingAPI
{
    public interface ICurbsideCommands
    {
        Task<GetCurbsideResponse> PlaceOrder(PostCurbsideRequest request);
    }
}