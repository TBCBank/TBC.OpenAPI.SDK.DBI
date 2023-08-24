using Microsoft.Extensions.Options;
using MovementEIServiceReference;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Factories;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    internal class MovementAdapter : IMovementAdapter
    {
        private readonly ChannelFactory<MovementService> _channelFactory;

        public MovementAdapter(IOptions<ServiceSettings> options)
        {
            var serviceConfig = options.Value.MovementServiceConfig;
            var factory = new ChannelFactoryManager<MovementService>(serviceConfig.Endpoint);
            _channelFactory = factory.GetChannelFactory();
        }

        public async Task<GetAccountMovementsResponse> GetAccountMovements(GetAccountMovementsRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.GetAccountMovementsAsync(request).ConfigureAwait(false);
        }
    }
}
