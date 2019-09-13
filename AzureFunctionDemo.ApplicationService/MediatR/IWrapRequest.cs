using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunctionDemo.ApplicationService.MediatR
{
    public interface IWrapRequest<T> : IRequest<IActionResult>
    {
        T Data { get; set; }
    }
}
