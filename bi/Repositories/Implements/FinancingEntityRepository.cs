using Nameless.Ledger.BI.Repositories.Interfaces;
using Nameless.Ledger.BI.Services.Interfaces;
using Nameless.Ledger.Models;
using Nameless.WebApi.Repositories;

namespace Nameless.Ledger.BI.Repositories.Implements
{
    public class FinancingEntityRepository :
        GenericRepository<FinancingEntity>, IFinancingEntityRepository, IContextAccesible
    {
        NamelessBIContext IContextAccesible.Context => (NamelessBIContext)this._context;

        public FinancingEntityRepository(NamelessBIContext context) 
            : base(context)
        {
            
        }
    }
}
