using PaymentEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;
using TBC.OpenAPI.SDK.DBI.Utilities;

namespace TBC.OpenAPI.SDK.DBI.Adapters
{
    public class PaymentAdapter : IPaymentAdapter
    {
        private readonly ChannelFactoryManager<PaymentService> _factoryManger;

        public PaymentAdapter(ChannelFactoryManager<PaymentService> factoryManger)
        {
            _factoryManger = factoryManger;
        }

        public async Task<GetBatchPaymentIdResponse> GetBatchPaymentId(GetBatchPaymentIdRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManger.CreateChannel(securityCredentials);

            return await service.GetBatchPaymentIdAsync(request).ConfigureAwait(false);
        }

        public async Task<GetPaymentOrderStatusResponse> GetPaymentOrderStatus(GetPaymentOrderStatusRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManger.CreateChannel(securityCredentials);

            return await service.GetPaymentOrderStatusAsync(request).ConfigureAwait(false);
        }

        public async Task<GetSinglePaymentIdResponse> GetSinglePaymentId(GetSinglePaymentIdRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManger.CreateChannel(securityCredentials);

            return await service.GetSinglePaymentIdAsync(request).ConfigureAwait(false);
        }

        public async Task<ImportBatchPaymentOrderResponse> ImportBatchPaymentOrder(ImportBatchPaymentOrderRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManger.CreateChannel(securityCredentials);

            return await service.ImportBatchPaymentOrderAsync(request).ConfigureAwait(false);
        }

        public async Task<ImportSinglePaymentOrdersResponse> ImportSinglePaymentOrders(ImportSinglePaymentOrdersRequest request, SecurityCredentials securityCredentials)
        {
            var service = _factoryManger.CreateChannel(securityCredentials);

            return await service.ImportSinglePaymentOrdersAsync(request).ConfigureAwait(false);
        }
    }
}
