using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.SharedKernel
{
    public class GenericSpeaker
    {
        private readonly ILogger<GenericSpeaker> _logger;

        public GenericSpeaker(ILogger<GenericSpeaker> logger)
        {
            _logger = logger;
        }


        public void SayHello()
        {
            _logger.LogInformation("Hello, SimpleInjector!");
        }
    }

    public class FactorySpeaker
    {
        private readonly ILogger<FactorySpeaker> _logger;

        public FactorySpeaker(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<FactorySpeaker>();
        }


        public void SayHello()
        {
            _logger.LogInformation("Hello, SimpleInjector!");
        }
    }


    public class Speaker
    {
        private readonly ILogger _logger;

        public Speaker(ILogger logger)
        {
            _logger = logger;
        }


        public void SayHello()
        {
            _logger.LogInformation("Hello, SimpleInjector!");
        }
    }
}
