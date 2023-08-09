using Nameless.Ledger.BI.Repositories.Interfaces;
using Nameless.Ledger.BI.Services.Interfaces;
using Nameless.Ledger.Models;
using Nameless.WebApi.Repositories;

namespace Nameless.Ledger.BI.Repositories.Implements
{
    public class TestRepository :
        GenericRepository<TestModel>, ITestRepository, IContextAccesible
    {
        NamelessBIContext IContextAccesible.Context => (NamelessBIContext)this._context;

        public TestRepository(NamelessBIContext context) 
            : base(context)
        {
            
        }
    }
}
