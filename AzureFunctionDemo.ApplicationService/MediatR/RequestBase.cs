using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.ApplicationService.MediatR
{
    public class RequestBase<T> : IWrapRequest<T>
    {
        public T Data { get; set; }
    }
}
