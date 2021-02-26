using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Project_Food_Service_Aggregator.Data;
using Final_Project_Food_Service_Aggregator.Models;

namespace Final_Project_Food_Service_Aggregator.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext _context;

        public EditModel(Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.DeliveryPartner)
                .Include(o => o.Restaurant).FirstOrDefaultAsync(m => m.OrderId == id);

            if (Order == null)
            {
                return NotFound();
            }
           ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Name");
           ViewData["DeliveryPartnerId"] = new SelectList(_context.DeliveryPartner, "DeliveryPartnerId", "Name");
           ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "RestaurantId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Name");
            ViewData["DeliveryPartnerId"] = new SelectList(_context.DeliveryPartner, "DeliveryPartnerId", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "RestaurantId", "Name");

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var restaurantId = Order.RestaurantId;
            TimeSpan orderTime = Order.Date.TimeOfDay;
            var restaurant = await _context.Restaurant.Where(x => x.RestaurantId == restaurantId).ToListAsync();
            TimeSpan restaurantStartTime = restaurant[0].StartTime;
            TimeSpan restaurantEndTime = restaurant[0].EndTime;
            if ((orderTime < restaurantStartTime) || (orderTime > restaurantEndTime))
            {
                ModelState.AddModelError("Order.Date", "The Order Time should be within Restaurant Start Time and End Time");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
