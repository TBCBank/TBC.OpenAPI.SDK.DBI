using MovementEIServiceReference;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class MovementAdapter : IMovementAdapter
    {
        private readonly ChannelFactory<MovementService> _channelFactory;

        public MovementAdapter(ChannelFactory<MovementService> channelFactory)
        {
            _channelFactory = channelFactory;
        }

        public async Task<GetAccountMovementsResponse> GetAccountMovements(GetAccountMovementsRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.GetAccountMovementsAsync(request).ConfigureAwait(false);
        }
    }
}
