using ChangePasswordEIServiceReference;
using Microsoft.Extensions.Options;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Factories;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    internal class ChangePasswordAdapter : IChangePasswordAdapter
    {
        private readonly ChannelFactory<ChangePasswordService> _channelFactory;

        public ChangePasswordAdapter(IOptions<ServiceSettings> options)
        {
            var serviceConfig = options.Value.ChangePasswordServiceConfig; 
            var factory = new ChannelFactoryManager<ChangePasswordService>(serviceConfig.Endpoint);
            _channelFactory = factory.GetChannelFactory();
        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.ChangePasswordAsync(request).ConfigureAwait(false);
        }
    }
}
