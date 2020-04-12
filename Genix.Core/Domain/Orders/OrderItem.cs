﻿using Genix.Core.Domain.Catalog;
using System;

namespace Genix.Core.Domain.Orders
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderItemGuid { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
