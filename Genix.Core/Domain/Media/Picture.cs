namespace Genix.Core.Domain.Media
{
    public class Picture : BaseEntity
    {
        public string MimeType { get; set; }
        public string SeaFilename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public virtual PictureBinary PictureBinary { get; set; }
        public string VirtualPath { get; set; }
    }
}
