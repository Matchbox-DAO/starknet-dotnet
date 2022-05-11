using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Diagnostics;
using StarkNet.Core.Abstractions;

namespace StarkNet.Core;

public static class RegistartionBuilder
{
    public static IServiceCollection RegisterStarkNetHttpProvider(this IServiceCollection services)//, IConfiguration configuration)
    {
        Guard.IsNotNull(services, nameof(services));
        //Guard.IsNotNull(configuration, nameof(configuration));
        
        services.AddHttpClient<IProvider, HttpProvider>();

        return services;
    }
}