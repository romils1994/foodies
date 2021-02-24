using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_Project_Food_Service_Aggregator.Models;

namespace Final_Project_Food_Service_Aggregator.Data
{
    public class Final_Project_Food_Service_AggregatorContext : DbContext
    {
        public Final_Project_Food_Service_AggregatorContext (DbContextOptions<Final_Project_Food_Service_AggregatorContext> options)
            : base(options)
        {
        }

        public DbSet<Final_Project_Food_Service_Aggregator.Models.Restaurant> Restaurant { get; set; }

        public DbSet<Final_Project_Food_Service_Aggregator.Models.Order> Order { get; set; }

        public DbSet<Final_Project_Food_Service_Aggregator.Models.DeliveryPartner> DeliveryPartner { get; set; }

        public DbSet<Final_Project_Food_Service_Aggregator.Models.Customer> Customer { get; set; }
    }
}
