using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Utilities
{
    public class ChannelFactoryManager<TService> where TService : class
    {
        private readonly ServiceConfig _config;

        public ChannelFactory<TService> ChannelFactory { get; }
        public EndpointAddress Endpoint { get; }
        public CustomBinding Binding { get; }

        public ChannelFactoryManager(ServiceConfig config)
        {
            _config= config;

            Endpoint = new EndpointAddress(_config.Endpoint);
            Binding = new CustomBinding();

            var encoding = new TextMessageEncodingBindingElement()
            {
                MessageVersion = MessageVersion.Soap11,
                WriteEncoding = Encoding.UTF8,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max
            };

            Binding.Elements.Add(encoding);

            var transport = new HttpsTransportBindingElement
            {
                MaxReceivedMessageSize = 20000000
            };

            Binding.Elements.Add(transport);

            ChannelFactory =  new ChannelFactory<TService>(Binding, Endpoint);
        }

        public TService CreateChannel(SecurityCredentials securityCredentials)
        {
            ChannelFactory.Endpoint.EndpointBehaviors.Add(new SoapEndpointBehavior(securityCredentials));
            return ChannelFactory.CreateChannel();
        }
    }
}
