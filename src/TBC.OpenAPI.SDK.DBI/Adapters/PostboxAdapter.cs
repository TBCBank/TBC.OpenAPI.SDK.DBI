using PostboxEIServiceReference;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class PostboxAdapter : IPostboxAdapter
    {
        private readonly ChannelFactory<PostboxService> _channelFactory;

        public PostboxAdapter(ChannelFactory<PostboxService> channelFactory)
        {
            _channelFactory = channelFactory;
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
