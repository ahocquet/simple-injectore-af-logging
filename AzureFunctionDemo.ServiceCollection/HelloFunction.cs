using System.Threading.Tasks;
using AzureFunctionDemo.ApplicationService.Features.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.ServiceCollection
{
    public class UserFunction : FunctionBase
    {
        public UserFunction(IMediator mediator) : base(mediator)
        {
        }

        [FunctionName(nameof(GetUser))]
        public Task<IActionResult> GetUser(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetUser/{id}")]
            string id,
            ILogger log)
            => Handle<Get.Query, string>(log, id);


        [FunctionName(nameof(CreateUser))]
        public Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            User user,
            ILogger log)
            => Handle<Create.Command, User>(log, user);
    }
}
