using ChangePasswordEIServiceReference;
using Microsoft.Extensions.DependencyInjection;
using MovementEIServiceReference;
using PaymentEIServiceReference;
using PostboxEIServiceReference;
using StatementEIServiceReference;
using TBC.OpenAPI.SDK.DBI.Adapters;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Utilities;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDBIServices(this IServiceCollection services, ServiceSettings settings)
        {
            if (settings.ChangePasswordServiceConfig != null)
            {
                services.AddTransient(_ =>
                {
                    return new ChannelFactoryManager<ChangePasswordService>(settings.ChangePasswordServiceConfig);
                });
                services.AddTransient<IChangePasswordAdapter, ChangePasswordAdapter>();
            }

            if (settings.MovementServiceConfig != null)
            {
                services.AddTransient(_ =>
                {
                    return new ChannelFactoryManager<MovementService>(settings.MovementServiceConfig);
                });
                services.AddTransient<IMovementAdapter, MovementAdapter>();
            }

            if (settings.PaymentServiceConfig != null)
            {
                services.AddTransient(_ =>
                {
                    return new ChannelFactoryManager<PaymentService>(settings.PaymentServiceConfig);
                });
                services.AddTransient<IPaymentAdapter, PaymentAdapter>();
            }

            if (settings.PostboxServiceConfig != null)
            {
                services.AddTransient(_ =>
                {
                    return new ChannelFactoryManager<PostboxService>(settings.PostboxServiceConfig);
                });
                services.AddTransient<IPostboxAdapter, PostboxAdapter>();
            }

            if (settings.StatementServiceConfig != null)
            {
                services.AddTransient(_ =>
                {
                    return new ChannelFactoryManager<StatementService>(settings.StatementServiceConfig);
                });
                services.AddTransient<IStatementAdapter, StatementAdapter>();
            }

            return services;
        }
    }
}
