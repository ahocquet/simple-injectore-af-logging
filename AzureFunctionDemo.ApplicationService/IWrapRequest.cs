using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.ApplicationService
{
    public interface IWrapRequest<T> : IRequest<IActionResult>
    {
        ILogger Logger { get; set; }
        T       Data   { get; set; }
    }
}
