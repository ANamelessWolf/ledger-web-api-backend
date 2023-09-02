using Nameless.Ledger.BI.Repositories.Interfaces;
using Nameless.Ledger.BI.Services.Interfaces;
using Nameless.Ledger.Models;
using Nameless.WebApi.Repositories;

namespace Nameless.Ledger.BI.Repositories.Implements
{
    public class CategoryRepository :
        GenericRepository<Category>, ICategoryRepository, IContextAccesible
    {
        NamelessBIContext IContextAccesible.Context => (NamelessBIContext)this._context;

        public CategoryRepository(NamelessBIContext context) 
            : base(context)
        {
            
        }
    }
}
