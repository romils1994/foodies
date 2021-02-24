using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Food_Service_Aggregator.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        [DisplayName("Restaurant Name")]
        public string Name { get; set; }

        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Restaurant Address")]
        public string Address { 
            get
            {
                return AddressLine1 + " " + AddressLine2 + " " + City + " " + State + " " + ZipCode;
            }
        }

        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }
        
        [DisplayName("License Number")]
        public string LicenseNumber { get; set; }

        [DisplayName("Cuisine")]
        public RestaurantCuisine Cuisine { get; set; }

        [DisplayName("Rating")]
        public int? Rating { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }
        public List<Order> Orders { get; set; }
    }

    public enum RestaurantCuisine
    {
        Chinese,
        Thai,
        Italian,
        Indian,
        Mexican
    }
}
