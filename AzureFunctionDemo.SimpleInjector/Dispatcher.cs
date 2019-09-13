using System.Threading.Tasks;
using AzureFunctionDemo.ApplicationService.Logging;
using AzureFunctionDemo.ApplicationService.MediatR;
using AzureFunctionDemo.SimpleInjector.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleInjector;

namespace AzureFunctionDemo.SimpleInjector
{
    public static class Dispatcher
    {
        private static Container Container => DIConfig.Container;

        public static Task<IActionResult> Handle<TCommand, TData>(ILogger log, TData data) where TCommand : IWrapRequest<TData>, new()
        {
            AzureFunctionLogger.Logger = log;
            var command = new TCommand {Data = data};
            return Container.GetInstance<Mediator>().Send(command);
        }
    }
}
