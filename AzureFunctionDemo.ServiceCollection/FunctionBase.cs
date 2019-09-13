using System.Threading.Tasks;
using AzureFunctionDemo.ApplicationService.Logging;
using AzureFunctionDemo.ApplicationService.MediatR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.ServiceCollection
{
    public abstract class FunctionBase
    {
        private readonly IMediator _mediator;

        protected FunctionBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected Task<IActionResult> Handle<TCommand, TData>(ILogger log, TData data) where TCommand : IWrapRequest<TData>, new()
        {
            AzureFunctionLogger.Logger = log;

            var command = new TCommand {Data = data};
            return _mediator.Send(command);
        }
    }
}