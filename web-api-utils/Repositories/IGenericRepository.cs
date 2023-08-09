using Nameless.WebApi.Models;

namespace Nameless.WebApi.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> Filter(string filter);
        Task<IEnumerable<T>> Search(string filter);
        Task<Tuple<int, IEnumerable<T>>> GetPage(int pageIndex, int pageSize, string filter = null, OrderRequest orderRequest = null);
    }
}
