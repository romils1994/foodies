using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Food_Service_Aggregator.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string ShippingAddress { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string AdditionalNote { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DeliveryPartner DeliveryPartner { get; set; }
        public int DeliveryPartnerId { get; set; }
    }
}
