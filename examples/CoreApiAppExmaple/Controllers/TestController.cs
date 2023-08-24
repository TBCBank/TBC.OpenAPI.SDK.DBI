using ChangePasswordEIServiceReference;
using Microsoft.AspNetCore.Mvc;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;

namespace CoreApiAppExmaple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IChangePasswordAdapter _changePasswordAdapter;

        public TestController(IChangePasswordAdapter changePasswordAdapter)
        {
            _changePasswordAdapter = changePasswordAdapter;
        }

        [HttpPost("password")]
        public async Task<ActionResult<ChangePasswordResponse>> GetApplicationStatus([FromBody] string newPass, CancellationToken cancellationToken = default)
        {
            var result = await _changePasswordAdapter.ChangePassword(new ChangePasswordRequest()
            {
                newPassword = newPass
            }, new SecurityCredentials()
            {
                Username="USERNAME",
                Password = "PASSWORD",
                Nonce = "NONCE"
            });

            return Ok(result);
        }
    }
}
