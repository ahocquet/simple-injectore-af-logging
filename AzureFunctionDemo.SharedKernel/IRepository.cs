using System.Threading.Tasks;

namespace AzureFunctionDemo.ApplicationService
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(string id);
        Task Insert(T entity);
    }
}
