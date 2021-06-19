using Provider.Abstract;

namespace Provider.Models
{
    public class Service : ProviderService
    {
        public bool IsPaymentOnceMonth { get; set; }
        public string Type { get; set; }
    }
}
