using System;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.ApplicationService.Logging
{
    public class AzureFunctionLogger : ILogger
    {
        public static ILogger Logger { get; set; }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Logger?.Log(logLevel, eventId, state, exception, formatter);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return Logger?.IsEnabled(logLevel) ?? false;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return Logger?.BeginScope(state);
        }
    }
}
