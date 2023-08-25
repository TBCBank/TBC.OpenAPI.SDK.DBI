using ChangePasswordEIServiceReference;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class ChangePasswordAdapter : IChangePasswordAdapter
    {
        private readonly ChannelFactory<ChangePasswordService> _channelFactory;

        public ChangePasswordAdapter(ChannelFactory<ChangePasswordService> channelFactory)
        {
            _channelFactory = channelFactory;
        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.ChangePasswordAsync(request).ConfigureAwait(false);
        }
    }
}
