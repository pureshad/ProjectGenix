using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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
