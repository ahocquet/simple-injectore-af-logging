using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.ApplicationService
{
    public class RequestBase<T> : IWrapRequest<T>
    {
        public ILogger Logger { get; set; }
        public T       Data   { get; set; }
    }
}