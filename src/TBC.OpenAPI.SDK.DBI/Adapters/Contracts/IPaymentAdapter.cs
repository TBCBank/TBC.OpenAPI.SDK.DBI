using PaymentEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Adapters.Contracts
{
    public interface IPaymentAdapter
    {
        Task<ImportSinglePaymentOrdersResponse> ImportSinglePaymentOrders(ImportSinglePaymentOrdersRequest request, SecurityCredentials securityCredentials);

        Task<ImportBatchPaymentOrderResponse> ImportBatchPaymentOrder(ImportBatchPaymentOrderRequest request, SecurityCredentials securityCredentials);

        Task<GetPaymentOrderStatusResponse> GetPaymentOrderStatus(GetPaymentOrderStatusRequest request, SecurityCredentials securityCredentials);
        
        Task<GetSinglePaymentIdResponse> GetSinglePaymentId(GetSinglePaymentIdRequest request, SecurityCredentials securityCredentials);
        
        Task<GetBatchPaymentIdResponse> GetBatchPaymentId(GetBatchPaymentIdRequest request, SecurityCredentials securityCredentials);
    }
}
