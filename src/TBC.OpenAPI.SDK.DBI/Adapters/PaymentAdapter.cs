using Microsoft.Extensions.Options;
using PaymentEIServiceReference;
using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Factories;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    internal class PaymentAdapter : IPaymentAdapter
    {
        private readonly ChannelFactory<PaymentService> _channelFactory;

        public PaymentAdapter(IOptions<ServiceSettings> options)
        {
            var serviceConfig = options.Value.PaymentServiceConfig;
            var factory = new ChannelFactoryManager<PaymentService>(serviceConfig.Endpoint);
            _channelFactory = factory.GetChannelFactory();
        }

        public async Task<GetBatchPaymentIdResponse> GetBatchPaymentId(GetBatchPaymentIdRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.GetBatchPaymentIdAsync(request).ConfigureAwait(false);
        }

        public async Task<GetPaymentOrderStatusResponse> GetPaymentOrderStatus(GetPaymentOrderStatusRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.GetPaymentOrderStatusAsync(request).ConfigureAwait(false);
        }

        public async Task<GetSinglePaymentIdResponse> GetSinglePaymentId(GetSinglePaymentIdRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.GetSinglePaymentIdAsync(request).ConfigureAwait(false);
        }

        public async Task<ImportBatchPaymentOrderResponse> ImportBatchPaymentOrder(ImportBatchPaymentOrderRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.ImportBatchPaymentOrderAsync(request).ConfigureAwait(false);
        }

        public async Task<ImportSinglePaymentOrdersResponse> ImportSinglePaymentOrders(ImportSinglePaymentOrdersRequest request, SecurityCredentials securityCredentials)
        {
            var service = _channelFactory.GetService(securityCredentials);

            return await service.ImportSinglePaymentOrdersAsync(request).ConfigureAwait(false);
        }
    }
}
