using ShoppingAPI.Models.Curbside;
using System.Threading.Tasks;

namespace ShoppingAPI
{
    public interface ICurbsideLookups
    {
        Task<GetCurbsideResponse> GetById(int id);
    }
}