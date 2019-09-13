using System.Threading.Tasks;
using AzureFunctionDemo.ApplicationService.Features.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.SimpleInjector
{
    public static class UserFunction
    {
        [FunctionName(nameof(GetUser))]
        public static Task<IActionResult> GetUser(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetUser/{id}")]
            string id,
            ILogger log)
            => Dispatcher.Handle<Get.Query, string>(log, id);


        [FunctionName(nameof(CreateUser))]
        public static Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            User user,
            ILogger log)
            => Dispatcher.Handle<Create.Command, User>(log, user);
    }
}
