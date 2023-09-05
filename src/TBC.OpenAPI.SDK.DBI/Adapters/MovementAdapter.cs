using MovementEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class MovementAdapter : IMovementAdapter
    {
        private readonly ChannelFactoryManager<MovementService> _factoryManager;

        public MovementAdapter(ChannelFactoryManager<MovementService> factoryManager)
        {
            _factoryManager = factoryManager;
        }

        public async Task<GetAccountMovementsResponse> GetAccountMovements(GetAccountMovementsRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManager.CreateChannel(securityCredentials);

            return await service.GetAccountMovementsAsync(request).ConfigureAwait(false);
        }
    }
}
