using Nameless.Ledger.ModelTypes;
using Nameless.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.Utils
{
    public static class CatalogueUtils
    {
        public static CatalogueItem[] GetFinancingEntityTypeCatalogue
            (params FinancingEntityType[] ignore)
        {
            var items = Enum.GetValues(typeof(FinancingEntityType));
            var result = new List<CatalogueItem>();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var enuM = (FinancingEntityType)item;
                    result.Add(new CatalogueItem()
                    {
                        Id = (int)enuM,
                        Description = enuM.GetHeader()
                    });
                }
            }
            if (ignore != null && ignore.Length > 0)
                return result.Where(x => !ignore.Contains((FinancingEntityType)x.Id)).ToArray();
            return result.ToArray();
        }

        public static CatalogueItem[] GetCardTypeCatalogue
            (params CardType[] ignore)
        {
            var items = Enum.GetValues(typeof(CardType));
            var result = new List<CatalogueItem>();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var enuM = (FinancingEntityType)item;
                    result.Add(new CatalogueItem()
                    {
                        Id = (int)enuM,
                        Description = enuM.GetHeader()
                    });
                }
            }
            if (ignore != null && ignore.Length > 0)
                return result.Where(x => !ignore.Contains((CardType)x.Id)).ToArray();
            return result.ToArray();
        }
    }
}
