using AzureFunctionDemo.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.ServiceCollection
{
    public class HelloFunction
    {
        private readonly GenericSpeaker _genericSpeaker;
        private readonly Speaker        _speaker;
        private readonly FactorySpeaker _factorySpeaker;

        public HelloFunction(GenericSpeaker genericSpeaker, Speaker speaker, FactorySpeaker factorySpeaker)
        {
            _genericSpeaker = genericSpeaker;
            _speaker        = speaker;
            _factorySpeaker = factorySpeaker;
        }

        [FunctionName("TestGenericLogger")]
        public IActionResult TestGenericLogger(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            _genericSpeaker.SayHello();
            log.LogInformation("InTestGeneric Function");
            return new OkResult();
        }

        [FunctionName("TestLogger")]
        public IActionResult TestLogger(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            _speaker.SayHello();

            return new OkResult();
        }

        [FunctionName("TestLoggerFactory")]
        public IActionResult TestLoggerFactory(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            _factorySpeaker.SayHello();

            return new OkResult();
        }
    }
}
