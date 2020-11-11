using ShoppingAPI.Data;
using System;
using System.Threading.Tasks;

namespace ShoppingAPI.Services
{
    public interface IGenerateCurbsidePickupTimes
    {
        Task<DateTime?> GetPickupDate(CurbsideOrder order);
    }
}