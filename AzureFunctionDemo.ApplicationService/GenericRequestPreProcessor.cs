using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace AzureFunctionDemo.ApplicationService
{
    public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<RequestBase<TRequest>>
    {
        public Task Process(RequestBase<TRequest> request, CancellationToken cancellationToken)
        {
            AzureFunctionLogger.Logger = request.Logger;
            return Task.CompletedTask;
        }
    }
}
