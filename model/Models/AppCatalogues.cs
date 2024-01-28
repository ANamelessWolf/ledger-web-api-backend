using Nameless.Ledger.ModelTypes;
using Nameless.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.Models
{
    public class AppCatalogues
    {
        public CatalogueItem[] FinancingEntityType { get; set; }
        public CatalogueItem[] FinancingEntity { get; set; }
        public CatalogueItem[] CardType { get; set; }
        public CatalogueItem[] CreditCard { get; set; }
        public CatalogueItem[] Category { get; set; }
        public CatalogueItem[] SubCategory { get; set; }
        public CatalogueItem[] Vendor { get; set; }
    }
}
