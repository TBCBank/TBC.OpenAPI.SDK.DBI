namespace TBC.OpenAPI.SDK.DBI.Models
{
    public class ServiceSettings
    {
        public ServiceConfig ChangePasswordServiceConfig { get; set; }

        public ServiceConfig MovementServiceConfig { get; set; }

        public ServiceConfig PaymentServiceConfig { get; set; }

        public ServiceConfig PostboxServiceConfig { get; set; }

        public ServiceConfig StatementServiceConfig { get; set; }
    }
}
