using System.Collections.Generic;

namespace Genix.Core.Domain.Directory
{
    public class Country : BaseEntity
    {
        private ICollection<StateProvince> _stateProvinces;

        public string Name { get; set; }
        public bool AllowBilling { get; set; }
        public bool AllowShipping { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public int NumericIsoCode { get; set; }

        public virtual ICollection<StateProvince> StateProvinces
        {
            get => _stateProvinces ?? (_stateProvinces = new List<StateProvince>());
            protected set => _stateProvinces = value;
        }

    }
}
