﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project_Food_Service_Aggregator.Data;
using Final_Project_Food_Service_Aggregator.Models;

namespace Final_Project_Food_Service_Aggregator.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext _context;

        public IndexModel(Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.DeliveryPartner)
                .Include(o => o.Restaurant).ToListAsync();
        }
    }
}
