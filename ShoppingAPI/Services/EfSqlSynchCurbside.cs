using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Data;
using ShoppingAPI.Models.Curbside;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ShoppingAPI.Services
{
    public class EfSqlSynchCurbside : ICurbsideCommands, ICurbsideLookups
    {
        private readonly ShoppingDataContext _context;

        public EfSqlSynchCurbside(ShoppingDataContext context)
        {
            _context = context;
        }

        public async Task<GetCurbsideResponse> GetById(int id)
        {
            var response = await _context.CurbsideOrders
                                .SingleOrDefaultAsync(c => c.Id == id);

            if (response != null)
            {
                return new GetCurbsideResponse
                {
                    Id = response.Id,
                    For = response.For,
                    Items = response.Items.Split(',').Select(int.Parse).ToArray(),
                    PickupReadyAt = response.PickupReadyAt.Value
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<GetCurbsideResponse> PlaceOrder(PostCurbsideRequest request)
        {
            await Task.Delay(1000 * request.Items.Length);

            var order = new CurbsideOrder
            {
                For = request.For,
                Items = String.Join(",", request.Items),
                PickupReadyAt = DateTime.Now.AddHours(new Random().Next(2, 5))
            };

            _context.CurbsideOrders.Add(order);
            await _context.SaveChangesAsync();

            return new GetCurbsideResponse 
            { 
                Id = order.Id,
                For = order.For,
                Items = order.Items.Split(',').Select(int.Parse).ToArray(),
                PickupReadyAt = order.PickupReadyAt.Value
            };
        }
    }
}
