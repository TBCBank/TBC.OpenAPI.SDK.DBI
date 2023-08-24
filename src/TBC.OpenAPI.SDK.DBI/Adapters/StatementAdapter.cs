using Microsoft.Extensions.Options;
using StatementEIServiceReference;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Factories;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    internal class StatementAdapter : IStatementAdapter
    {
        private readonly ChannelFactory<StatementService> _channelFactory;

        public StatementAdapter(IOptions<ServiceSettings> options)
        {
            var serviceConfig = options.Value.StatementServiceConfig;
            var factory = new ChannelFactoryManager<StatementService>(serviceConfig.Endpoint);
            _channelFactory = factory.GetChannelFactory();
        }

        public async Task<GetAccountStatementResponse> GetAccountStatement(GetAccountStatementRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.GetAccountStatementAsync(request).ConfigureAwait(false);
        }
    }
}
