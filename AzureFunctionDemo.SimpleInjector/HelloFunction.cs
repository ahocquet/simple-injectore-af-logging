using AzureFunctionDemo.SharedKernel;
using AzureFunctionDemo.SimpleInjector.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.SimpleInjector
{
    public static class HelloFunction
    {
        [FunctionName("TestGenericLogger")]
        public static IActionResult TestGenericLogger(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            DIConfig.Container.GetInstance<GenericSpeaker>().SayHello();

            return new OkResult();
        }

        [FunctionName("TestLogger")]
        public static IActionResult TestLogger(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            DIConfig.Container.GetInstance<Speaker>().SayHello();

            return new OkResult();
        }

        [FunctionName("TestLoggerFactory")]
        public static IActionResult TestLoggerFactory(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            DIConfig.Container.GetInstance<FactorySpeaker>().SayHello();

            return new OkResult();
        }
    }
}
