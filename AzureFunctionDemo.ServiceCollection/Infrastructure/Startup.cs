using AzureFunctionDemo.ServiceCollection.Infrastructure;
using AzureFunctionDemo.SharedKernel;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureFunctionDemo.ServiceCollection.Infrastructure
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<Speaker>();
            builder.Services.AddTransient<GenericSpeaker>();
            builder.Services.AddTransient<FactorySpeaker>();
        }
    }
}
