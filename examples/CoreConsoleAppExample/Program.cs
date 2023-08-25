using ChangePasswordEIServiceReference;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TBC.OpenAPI.SDK.DBI.Adapters.Contracts;
using TBC.OpenAPI.SDK.DBI.Extensions;
using TBC.OpenAPI.SDK.DBI.Models;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(hostConfig =>
    {
        hostConfig.AddJsonFile("appsettings.json", optional: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<ServiceSettings>(hostContext.Configuration.GetSection("ServiceConfigs"))
            .AddDBIServices(hostContext.Configuration.GetSection("ServiceConfigs").Get<ServiceSettings>());
    }).Build();

var changePasswordService = builder.Services
        .GetService<IChangePasswordAdapter>();

changePasswordService?.ChangePassword(new ChangePasswordRequest()
{
    newPassword = "NEW_PASSWORD"
},
new SecurityCredentials()
{
    Username = "USERNAME",
    Password = "PASSWORD",
    Nonce = "NONCE"
});