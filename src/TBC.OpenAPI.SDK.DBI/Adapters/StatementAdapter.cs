using StatementEIServiceReference;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class StatementAdapter : IStatementAdapter
    {
        private readonly ChannelFactory<StatementService> _channelFactory;

        public StatementAdapter(ChannelFactory<StatementService> channelFactory)
        {
            _channelFactory = channelFactory;
        }

        public async Task<GetAccountStatementResponse> GetAccountStatement(GetAccountStatementRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.GetAccountStatementAsync(request).ConfigureAwait(false);
        }
    }
}
