using System.ServiceModel;
using System.Text;

namespace TBC.OpenAPI.SDK.DBI.Factories
{
    internal static class ChannelFactoryManager<TService> where TService : class
    {
        public static ChannelFactory<TService> GetChannelFactory(string endpoint)
        {
            var endpointAddress = new EndpointAddress(endpoint);
            HttpBindingBase binding;

            if (endpointAddress.Uri.Scheme == "https")
            {
                binding = new BasicHttpsBinding();
            }
            else
            {
                binding = new BasicHttpBinding();
            }

            binding.TextEncoding = Encoding.UTF8;

            return new ChannelFactory<TService>(binding, endpointAddress);
        }
    }
}
