using StatementEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Adapters.Contracts
{
    public interface IStatementAdapter
    {
        Task<GetAccountStatementResponse> GetAccountStatement(GetAccountStatementRequest request, SecurityCredentials securityCredentials);
    }
}
