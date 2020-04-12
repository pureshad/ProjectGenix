using Genix.Core.Domain.Orders;
using System;
using System.Collections.Generic;

namespace Genix.Core.Domain.Shipping
{
    public class Shipment : BaseEntity
    {
        private ICollection<ShipmentItem> _shipmentItems;

        public int OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDateUtc { get; set; }
        public DateTime? DeliveryDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<ShipmentItem> ShipmentItems
        {
            get => _shipmentItems ?? (_shipmentItems = new List<ShipmentItem>());
            protected set => _shipmentItems = value;
        }
    }
}
