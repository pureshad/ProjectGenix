using System;
using System.Collections.Generic;

namespace Genix.Core.Domain.Catalog
{
    public class Product : BaseEntity
    {
        private ICollection<ProductCategory> _productCategories;
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public string Sku { get; set; }
        public bool IsShipEnabled { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public bool Published { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories
        {
            get => _productCategories ?? (_productCategories = new List<ProductCategory>());
            protected set => _productCategories = value;
        }
    }
}
