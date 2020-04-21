using System.Collections.Generic;
using System.Linq;

namespace Genix.Services.RequestsAndResults
{
    public class CustomerRegistrationResult
    {
        public IList<string> Errors { get; set; }

        public bool Success => !Errors.Any();

        public CustomerRegistrationResult()
        {
            Errors = new List<string>();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
