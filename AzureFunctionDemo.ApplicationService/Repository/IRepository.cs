using System.Threading.Tasks;

namespace AzureFunctionDemo.ApplicationService.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(string id);
        Task Insert(T entity);
    }
}
