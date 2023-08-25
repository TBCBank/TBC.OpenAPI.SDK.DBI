# TBC.OpenAPI.SDK.DBI
​
[![NuGet version (TBC.OpenAPI.SDK.DBI)](https://img.shields.io/nuget/v/TBC.OpenAPI.SDK.DBI.svg?label=TBC.OpenAPI.SDK.DBI)](https://www.nuget.org/packages/TBC.OpenAPI.SDK.DBI)
​​
## DBI SDK
​
Repository contains the SDK for simplifying integration of TBC DBI Services for C# client application side.\
​
Library is written in the C# programming language and is compatible with .netstandard2.0 and .net6.0.
​
## Prerequisites
​
In order to use the SDK it is mandatory to have **web link**, **username**, **password** and **nonce** for test environment.
​
[See more details how to get parameters](https://developers.tbcbank.ge/docs/dbi-test-environment-parameters)
​
## .Net Core Usage
​
First step is to configure appsettings.json file with DBI service configuration (leave the sevice you want to use, so other ones will not be injected)\
​
appsettings.json
​
```json
​
"ServiceConfigs": {
    "ChangePasswordServiceConfig": {
      "Endpoint": "https://test.tbconline.ge/dbi/dbiService"
    },
    "MovementServiceConfig": {
      "Endpoint": "https://test.tbconline.ge/dbi/dbiService"
    },
    "PaymentServiceConfig": {
      "Endpoint": "https://test.tbconline.ge/dbi/dbiService"
    },
    "PostboxServiceConfig": {
      "Endpoint": "https://test.tbconline.ge/dbi/dbiService"
    },
    "StatementServiceConfig": {
      "Endpoint": "https://test.tbconline.ge/dbi/dbiService"
    }
  }
​
```
​
Then register Configuration and DBI Service adapters in dependency injection\
​
Program.cs
​
```cs
​
builder.Services.Configure<ServiceSettings>(builder.Configuration.GetSection("ServiceConfigs"));
builder.Services.AddDBIServices(builder.Configuration.GetSection("ServiceConfigs").Get<ServiceSettings>());
​
```
​
After two steps above, setup is done and DBI Service Adapters can be injected in any container class:
​
Injection example:
​
```cs
​
private readonly IChangePasswordAdapter _changePasswordAdapter;

public TestController(IChangePasswordAdapter changePasswordAdapter)
{
    _changePasswordAdapter = changePasswordAdapter;
}
​
```
​
Service invocation example:
​
```cs
​
var result = await _changePasswordAdapter.ChangePassword(
    new ChangePasswordRequest()
    {
        newPassword = newPasswordValue
    }, 
    new SecurityCredentials()
    {
        Username="USERNAME",
        Password = "PASSWORD",
        Nonce = "NONCE"
    });
​
```
​​
For more details see examples in repo:
​

[CoreApiAppExmaple](https://github.com/TBCBank/TBC.OpenAPI.SDK.DBI/tree/master/examples/CoreApiAppExmaple)
​

[CoreConsoleAppExample](https://github.com/TBCBank/TBC.OpenAPI.SDK.DBI/tree/master/examples/CoreConsoleAppExample)
