using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Food_Service_Aggregator.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

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

        [DisplayName("Shipping Address")]
        public string ShippingAddress { get; set; }


        [DisplayName("Total Amount")]
        public decimal Total { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Additional Notes")]
        public string AdditionalNote { get; set; }

        [DisplayName("Restaurant")]
        public Restaurant Restaurant { get; set; }

        [DisplayName("Restaurant Name")]
        public int RestaurantId { get; set; }

        [DisplayName("Customer")]
        public Customer Customer { get; set; }

        [DisplayName("Customer Name")]
        public int CustomerId { get; set; }

        [DisplayName("Delivery Partner")]
        public DeliveryPartner DeliveryPartner { get; set; }

        [DisplayName("Delivery Partner Name")]
        public int DeliveryPartnerId { get; set; }
    }
}
