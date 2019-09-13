using System.Threading;
using System.Threading.Tasks;
using AzureFunctionDemo.ApplicationService.MediatR;
using AzureFunctionDemo.ApplicationService.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunctionDemo.ApplicationService.Features.User
{
    public class Create
    {
        public class Command : RequestBase<User>
        {
        }

        public class CreateHandler : IRequestHandler<Command, IActionResult>
        {
            private readonly IRepository<User> _repository;

            public CreateHandler(IRepository<User> repository)
            {
                _repository = repository;
            }

            public async Task<IActionResult> Handle(Command command, CancellationToken cancellationToken)
            {
                await _repository.Insert(command.Data);
                return new OkResult();
            }
        }
    }
}
