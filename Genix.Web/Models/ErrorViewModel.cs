using Genix.Core;

namespace Genix.Web.Models
{
    public class ErrorViewModel : BaseEntity
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
