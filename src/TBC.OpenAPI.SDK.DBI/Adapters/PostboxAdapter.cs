using Microsoft.Extensions.Options;
using PostboxEIServiceReference;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Factories;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    internal class PostboxAdapter : IPostboxAdapter
    {
        private readonly ChannelFactory<PostboxService> _channelFactory;

        public PostboxAdapter(IOptions<ServiceSettings> options)
        {
            var serviceConfig = options.Value.PostboxServiceConfig;
            var factory = new ChannelFactoryManager<PostboxService>(serviceConfig.Endpoint);
            _channelFactory = factory.GetChannelFactory();
        }

        public async Task<AcknowledgePostboxMessagesResponse> AcknowledgePostboxMessages(AcknowledgePostboxMessagesRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.AcknowledgePostboxMessagesAsync(request).ConfigureAwait(false);
        }

        public async Task<GetMessagesFromPostboxResponse> GetMessagesFromPostbox(GetMessagesFromPostboxRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.GetMessagesFromPostboxAsync(request).ConfigureAwait(false);
        }
    }
}
