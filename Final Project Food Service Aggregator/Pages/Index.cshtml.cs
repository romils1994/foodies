﻿using Final_Project_Food_Service_Aggregator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Food_Service_Aggregator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext _context;

        public IndexModel(Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext context)
        {
            _context = context;
        }

        public bool SearchCompleted { get; set; }

        public IList<Restaurant> Restaurant { get; set; }

        public IList<Restaurant> TopRatedRestaurant { get; set; }

        public IList<Restaurant> ServingNowRestaurant { get; set; }

        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                SearchCompleted = true;
                Restaurant = await _context.Restaurant.Where(x => x.Name.Contains(query) || x.Cuisine.Contains(query)).ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                TopRatedRestaurant = await _context.Restaurant.Where(x => x.Rating >= 4).Take(4).ToListAsync();
                var currentTime = DateTime.Now.TimeOfDay;
                ServingNowRestaurant = await _context.Restaurant.Where(x => currentTime >= x.StartTime && currentTime <= x.EndTime).Take(4).ToListAsync();
            }
        }
    }
}
