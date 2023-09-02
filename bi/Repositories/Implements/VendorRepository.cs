using Nameless.Ledger.BI.Repositories.Interfaces;
using Nameless.Ledger.BI.Services.Interfaces;
using Nameless.Ledger.Models;
using Nameless.WebApi.Repositories;

namespace Nameless.Ledger.BI.Repositories.Implements
{
    public class VendorRepository :
        GenericRepository<Vendor>, IVendorRepository, IContextAccesible
    {
        NamelessBIContext IContextAccesible.Context => (NamelessBIContext)this._context;

        public VendorRepository(NamelessBIContext context) 
            : base(context)
        {
            
        }
    }
}
