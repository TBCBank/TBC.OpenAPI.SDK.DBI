using MovementEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Adapters.Contracts
{
    public interface IMovementAdapter
    {
        Task<GetAccountMovementsResponse> GetAccountMovements(GetAccountMovementsRequest request, SecurityCredentials securityCredentials);
    }
}
