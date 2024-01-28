using Nameless.Ledger.BI.Repositories.Interfaces;
using Nameless.Ledger.BI.Services.Interfaces;
using Nameless.Ledger.Models;
using Nameless.WebApi.Repositories;

namespace Nameless.Ledger.BI.Repositories.Implements
{
    public class CreditCardOverviewRepository :
        GenericRepository<CreditCardOverview>, ICreditCardOverviewRepository, IContextAccesible
    {
        NamelessBIContext IContextAccesible.Context => (NamelessBIContext)this._context;


        public CreditCardOverviewRepository(NamelessBIContext context) 
            : base(context)
        {
            
        }
    }
}
