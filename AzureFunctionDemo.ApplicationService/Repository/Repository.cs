using System.Threading.Tasks;
using AutoBogus;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo.ApplicationService.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ILogger _logger;
        private readonly string  _typeName;

        public Repository(ILogger logger)
        {
            _logger   = logger;
            _typeName = typeof(T).Name;
        }

        public Task<T> GetById(string id)
        {
            _logger.LogInformation($"Retrieving {_typeName} with ID {id} from repository...");

            var result = AutoFaker.Generate<T>();
            return Task.FromResult(result);
        }

        public Task Insert(T entity)
        {
            _logger.LogInformation($"Inserting {_typeName} into repository: {entity}");
            return Task.CompletedTask;
        }
    }
}
