using Nameless.Ledger.BI.Models;

namespace Nameless.Ledger.BI.Services.Interfaces
{
    public interface IExecuteSpService<T> where T : class
    {
        Task<IEnumerable<T>> ExecuteStoredProcedure(RequestStoredProcedure request);
    }
}
