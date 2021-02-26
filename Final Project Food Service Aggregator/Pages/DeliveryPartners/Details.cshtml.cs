using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project_Food_Service_Aggregator.Data;
using Final_Project_Food_Service_Aggregator.Models;

namespace Final_Project_Food_Service_Aggregator.Pages.DeliveryPartners
{
    public class DetailsModel : PageModel
    {
        private readonly Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext _context;

        public DetailsModel(Final_Project_Food_Service_Aggregator.Data.Final_Project_Food_Service_AggregatorContext context)
        {
            _context = context;
        }

        public DeliveryPartner DeliveryPartner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeliveryPartner = await _context.DeliveryPartner
                .Include(x => x.Orders)
                .FirstOrDefaultAsync(m => m.DeliveryPartnerId == id);

            if (DeliveryPartner == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
