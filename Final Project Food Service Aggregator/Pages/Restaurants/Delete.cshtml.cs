﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project_Food_Service_Aggregator.Data;
using Final_Project_Food_Service_Aggregator.Models;

namespace Final_Project_Food_Service_Aggregator.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext _context;

        public DeleteModel(Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.RestaurantId == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurant.FindAsync(id);

            if (Restaurant != null)
            {
                _context.Restaurant.Remove(Restaurant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
