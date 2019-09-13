using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AzureFunctionDemo.ApplicationService;
using AzureFunctionDemo.ApplicationService.Features.User;
using AzureFunctionDemo.ApplicationService.Logging;
using AzureFunctionDemo.ApplicationService.MediatR;
using AzureFunctionDemo.ApplicationService.Repository;
using AzureFunctionDemo.SimpleInjector.Infrastructure;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            Container.RegisterSingleton<ILogger, AzureFunctionLogger>();
            Container.Register<IRepository<User>, Repository<User>>();

            RegisterMediatR(Container);

            serviceCollection.BuildServiceProvider()
                             .UseSimpleInjector(Container);
        }

        private static void RegisterMediatR(Container container)
        {
            var assemblies = GetAssemblies().ToArray();

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);

            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites             = false
            });
            container.Collection.Register(typeof(INotificationHandler<>), notificationHandlerTypes);

            //Pipeline
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>),
            });

            container.Collection.Register(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            container.Collection.Register(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(User).Assembly;
        }
    }
}
