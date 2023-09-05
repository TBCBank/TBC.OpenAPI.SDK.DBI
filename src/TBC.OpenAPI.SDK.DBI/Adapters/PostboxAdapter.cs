using PostboxEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class PostboxAdapter : IPostboxAdapter
    {
        private readonly ChannelFactoryManager<PostboxService> _factoryManager;

        public PostboxAdapter(ChannelFactoryManager<PostboxService> factoryManager)
        {
            _factoryManager = factoryManager;
        }

        public async Task<AcknowledgePostboxMessagesResponse> AcknowledgePostboxMessages(AcknowledgePostboxMessagesRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManager.CreateChannel(securityCredentials);

            return await service.AcknowledgePostboxMessagesAsync(request).ConfigureAwait(false);
        }

        public async Task<GetMessagesFromPostboxResponse> GetMessagesFromPostbox(GetMessagesFromPostboxRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManager.CreateChannel(securityCredentials);

            return await service.GetMessagesFromPostboxAsync(request).ConfigureAwait(false);
        }
    }
}
