using System.Threading;
using System.Threading.Tasks;
using AzureFunctionDemo.ApplicationService.MediatR;
using AzureFunctionDemo.ApplicationService.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunctionDemo.ApplicationService.Features.User
{
    public class Get
    {
        public class Query : RequestBase<string>
        {
        }

        public class CreateHandler : IRequestHandler<Query, IActionResult>
        {
            private readonly IRepository<User> _repository;

            public CreateHandler(IRepository<User> repository)
            {
                _repository = repository;
            }

            public async Task<IActionResult> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _repository.GetById(request.Data);
                return new OkObjectResult(user);
            }
        }
    }
}
