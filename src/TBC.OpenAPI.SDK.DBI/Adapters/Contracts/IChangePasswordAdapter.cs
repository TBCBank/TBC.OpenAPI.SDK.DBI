using ChangePasswordEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Adapters.Contracts
{
    public interface IChangePasswordAdapter
    {
        Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request, SecurityCredentials securityCredentials);
    }
}
