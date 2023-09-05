using StatementEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class StatementAdapter : IStatementAdapter
    {
        private readonly ChannelFactoryManager<StatementService> _factoryManager;

        public StatementAdapter(ChannelFactoryManager<StatementService> factoryManager)
        {
            _factoryManager = factoryManager;
        }

        public async Task<GetAccountStatementResponse> GetAccountStatement(GetAccountStatementRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManager.CreateChannel(securityCredentials);

            return await service.GetAccountStatementAsync(request).ConfigureAwait(false);
        }
    }
}
