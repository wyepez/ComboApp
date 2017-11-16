using System;

namespace ComboApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ExternalId { get; set; }
        public string TransactionType { get; set; }
        public int? BusinessAssociateId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Priority { get; set; }
        public string OrderType { get; set; }
        public string Status { get; set; }
        public string Information { get; set; }

        public string BusinessAssociateName { get; set; }
    }
}
