using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Food_Service_Aggregator.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("Customer First Name")]
        public string FirstName { get; set; }

        [DisplayName("Customer Last Name")]
        public string LastName { get; set; }

        [DisplayName("Name")]
        public string Name { 
            get {
                return FirstName + " " + LastName;
            } 
        }

        [DisplayName("Customer Address")]
        public string Address
        {
            get
            {
                return AddressLine1 + " " + AddressLine2 + " " + City + " " + State + " " + ZipCode;
            }
        }


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

        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }
}
