namespace Genix.Web.Models.Catalog
{
    public class ProductModel
    {
        public ProductType ProductType { get; set; }
    }

    public enum ProductType
    {
        All,
        Apparel,
        Toys,
        Games
    }
}
