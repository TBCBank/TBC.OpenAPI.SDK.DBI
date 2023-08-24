using Microsoft.Extensions.DependencyInjection;
using TBC.OpenAPI.SDK.DBI.Adapters;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDBIServices(this IServiceCollection services, ServiceSettings settings)
        {
            if (settings.ChangePasswordServiceConfig != null)
            {
                services.AddScoped<IChangePasswordAdapter, ChangePasswordAdapter>();
            }

            if (settings.MovementServiceConfig != null)
            {
                services.AddScoped<IMovementAdapter, MovementAdapter>();
            }

            if (settings.PaymentServiceConfig != null)
            {
                services.AddScoped<IPaymentAdapter, PaymentAdapter>();
            }

            if (settings.PostboxServiceConfig != null)
            {
                services.AddScoped<IPostboxAdapter, PostboxAdapter>();
            }

            if (settings.StatementServiceConfig != null)
            {
                services.AddScoped<IStatementAdapter, StatementAdapter>();
            }

            return services;
        }
    }
}
