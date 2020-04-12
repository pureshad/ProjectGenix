namespace Genix.Core.Domain.Directory
{
    public class StateProvince : BaseEntity
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public virtual Country Country { get; set; }
    }
}
