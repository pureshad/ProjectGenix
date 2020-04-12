namespace Genix.Core.Domain.Catalog
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
    }
}
