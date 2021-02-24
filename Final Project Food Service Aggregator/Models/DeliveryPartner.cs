using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Food_Service_Aggregator.Models
{
    public class DeliveryPartner
    {
        public int DeliveryPartnerId { get; set; }

        [DisplayName("Delivery Partner First Name")]
        public string FirstName { get; set; }

        [DisplayName("Delivery Partner Last Name")]
        public string LastName { get; set; }

        [DisplayName("Delivery Partner Name")]
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }
}
