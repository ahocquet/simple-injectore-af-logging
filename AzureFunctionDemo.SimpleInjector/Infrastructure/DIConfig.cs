using AzureFunctionDemo.SharedKernel;
using AzureFunctionDemo.SimpleInjector.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureFunctionDemo.SimpleInjector.Infrastructure
{
    // ReSharper disable once InconsistentNaming
    public static class DIConfig
    {
        public static readonly Container Container = new Container();

        public static void Init(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSimpleInjector(Container);

            Container.Register<Speaker>();
            Container.Register<GenericSpeaker>();
            Container.Register<FactorySpeaker>();

            serviceCollection.BuildServiceProvider()
                             .UseSimpleInjector(Container);
        }
    }
}
