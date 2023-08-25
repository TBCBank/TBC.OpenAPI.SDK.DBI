using ChangePasswordEIServiceReference;
using Microsoft.Extensions.DependencyInjection;
using MovementEIServiceReference;
using PaymentEIServiceReference;
using PostboxEIServiceReference;
using StatementEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Adapters;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Factories;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDBIServices(this IServiceCollection services, ServiceSettings settings)
        {
            if (settings.ChangePasswordServiceConfig != null)
            {
                services.AddSingleton(_ =>
                {
                    return ChannelFactoryManager<ChangePasswordService>.GetChannelFactory(settings.ChangePasswordServiceConfig.Endpoint);
                });
                services.AddScoped<IChangePasswordAdapter, ChangePasswordAdapter>();
            }

            if (settings.MovementServiceConfig != null)
            {
                services.AddSingleton(_ =>
                {
                    return ChannelFactoryManager<MovementService>.GetChannelFactory(settings.MovementServiceConfig.Endpoint);
                });
                services.AddScoped<IMovementAdapter, MovementAdapter>();
            }

            if (settings.PaymentServiceConfig != null)
            {
                services.AddSingleton(_ =>
                {
                    return ChannelFactoryManager<PaymentService>.GetChannelFactory(settings.PaymentServiceConfig.Endpoint);
                });
                services.AddScoped<IPaymentAdapter, PaymentAdapter>();
            }

            if (settings.PostboxServiceConfig != null)
            {
                services.AddSingleton(_ =>
                {
                    return ChannelFactoryManager<PostboxService>.GetChannelFactory(settings.PostboxServiceConfig.Endpoint);
                });
                services.AddScoped<IPostboxAdapter, PostboxAdapter>();
            }

            if (settings.StatementServiceConfig != null)
            {
                services.AddSingleton(_ =>
                {
                    return ChannelFactoryManager<StatementService>.GetChannelFactory(settings.StatementServiceConfig.Endpoint);
                });
                services.AddScoped<IStatementAdapter, StatementAdapter>();
            }

            return services;
        }
    }
}
