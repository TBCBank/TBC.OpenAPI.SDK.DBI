using System.ServiceModel;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Utilities
{
    internal static class ServiceInstanceCreator
    {
        internal static TService GetService<TService>(this ChannelFactory<TService> channelFactory, SecurityCredentials securityCredentials)
        {
            channelFactory.Endpoint.EndpointBehaviors.Add(new SoapEndpointBehavior(securityCredentials));
            return channelFactory.CreateChannel();
        }
    }
}
