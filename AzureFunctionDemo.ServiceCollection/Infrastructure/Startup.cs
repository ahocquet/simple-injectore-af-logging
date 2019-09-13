using AzureFunctionDemo.ApplicationService.Features.User;
using AzureFunctionDemo.ApplicationService.Logging;
using AzureFunctionDemo.ApplicationService.MediatR;
using AzureFunctionDemo.ApplicationService.Repository;
using AzureFunctionDemo.ServiceCollection.Infrastructure;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureFunctionDemo.ServiceCollection.Infrastructure
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            services.AddMediatR(typeof(Create.Command).Assembly);

            services.AddSingleton<ILogger, AzureFunctionLogger>();
            services.AddScoped<IRepository<User>, Repository<User>>();
        }
    }
}
