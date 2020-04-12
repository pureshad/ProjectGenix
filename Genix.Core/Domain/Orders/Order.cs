using Genix.Core.Domain.Common;
using Genix.Core.Domain.Customers;
using Genix.Core.Domain.Payments;
using Genix.Core.Domain.Shipping;
using System;
using System.Collections.Generic;

namespace Genix.Core.Domain.Orders
{
    public class Order : BaseEntity
    {
        private ICollection<OrderItem> _orderItems;
        private ICollection<Shipment> _shipments;
        public int CustomerId { get; set; }
        public Guid OrderGuid { get; set; }
        public int ShippingAddressId { get; set; }
        public int ShippingStatusId { get; set; }
        public string ShippingMethod { get; set; }
        public int BillingAddressId { get; set; }
        public bool Deleted { get; set; }
        public int PaymentStatusId { get; set; }
        public int PickupAddressId { get; set; }
        public decimal OrderTotal { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? PaidDateUtc { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual Address PickupAddress { get; set; }

        public virtual ICollection<OrderItem> OrderItems
        {
            get => _orderItems ?? (_orderItems = new List<OrderItem>());
            protected set => _orderItems = value;
        }
        public virtual ICollection<Shipment> Shipments
        {
            get => _shipments ?? (_shipments = new List<Shipment>());
            protected set => _shipments = value;
        }
        public OrderStatus OrderStatus
        {
            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;
        }
        public PaymentStatus PaymentStatus
        {
            get => (PaymentStatus)PaymentStatusId;
            set => PaymentStatusId = (int)value;
        }
        public ShippingStatus ShippingStatus
        {
            get => (ShippingStatus)ShippingStatusId;
            set => ShippingStatusId = (int)value;
        }

    }
}
