using ChangePasswordEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class ChangePasswordAdapter : IChangePasswordAdapter
    {
        private readonly ChannelFactoryManager<ChangePasswordService> _factoryManager;

        public ChangePasswordAdapter(ChannelFactoryManager<ChangePasswordService> factoryManager)
        {
            _factoryManager = factoryManager;
        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManager.CreateChannel(securityCredentials);

            return await service.ChangePasswordAsync(request).ConfigureAwait(false);
        }
    }
}
