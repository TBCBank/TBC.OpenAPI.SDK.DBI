using PostboxEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Adapters.Contracts
{
    public interface IPostboxAdapter
    {
        Task<GetMessagesFromPostboxResponse> GetMessagesFromPostbox(GetMessagesFromPostboxRequest request, SecurityCredentials securityCredentials);

        Task<AcknowledgePostboxMessagesResponse> AcknowledgePostboxMessages(AcknowledgePostboxMessagesRequest request, SecurityCredentials securityCredentials);
    }
}
