namespace TBC.OpenAPI.SDK.DBI.Models
{
    public class ServiceConfig
    {
        public string Endpoint { get; set; }

        internal void Validate()
        {
            if (string.IsNullOrEmpty(Endpoint))
            {
                throw new Exception($"{nameof(ServiceConfig)}.{nameof(Endpoint)} should not be empty");
            }
        }
    }
}
