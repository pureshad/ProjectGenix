using Genix.Core.Domain.Media;

namespace Genix.Core.Domain.Catalog
{
    public class ProductPicture : BaseEntity
    {
        public int ProductId { get; set; }
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual Product Product { get; set; }
    }
}
