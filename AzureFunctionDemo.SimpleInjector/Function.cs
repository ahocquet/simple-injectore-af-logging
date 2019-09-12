using System.Threading.Tasks;
using AzureFunctionDemo.ApplicationService;
using AzureFunctionDemo.SimpleInjector.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleInjector;

namespace AzureFunctionDemo.SimpleInjector
{
    public static class Function
    {
        private static Container Container => DIConfig.Container;

        public static Task<IActionResult> Handle<TCommand, TData>(ILogger log, TData data) where TCommand : IWrapRequest<TData>, new()
        {
            var command = new TCommand {Logger = log, Data = data};
            return Container.GetInstance<Mediator>().Send(command);
        }
    }
}