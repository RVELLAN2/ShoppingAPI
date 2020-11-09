﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Data;
using ShoppingAPI.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Services
{
    public class EfSqlShopping : ILookupProducts
    {
        private readonly ShoppingDataContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config;

        public EfSqlShopping(ShoppingDataContext context, IMapper mapper, MapperConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        public async Task<GetProductsResponse> GetSummary()
        {
            var response = new GetProductsResponse();

            var countInInventory = await _context.Products.CountAsync(p => p.InInventory);
            var countOutOfInvertory = await _context.Products.CountAsync(p => !p.InInventory);

            response.NumberOfProductsInInvetory = countInInventory;
            response.NumberOfProductsOutOfStock = countOutOfInvertory;
            response.NumberOfProductsAddedToday = new Random().Next(12, 300); //HA!

            return response;
        }

        public async Task<GetProductsListSummary> GetSummaryList(string category)
        {
            var list = await _context.GetItemsFromCategory(category)
                                .ProjectTo<ProductSummaryItem>(_config)
                                .ToListAsync();

            var response = new GetProductsListSummary
            {
                Data = list,
                Category = category,
                Count = list.Count()
            };

            return response;
        }
    }
}