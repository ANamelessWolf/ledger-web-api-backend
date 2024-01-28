using Nameless.Ledger.ModelTypes;
using Nameless.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.Models
{
    public class CreditCardOverview:DbModel
    {
        public int WalletId { get; set; }
        public int FinancingEntityId { get; set; }
        public string Name { get; set; }
        public string FinancingEntity { get; set; }
        public double Credit { get; set; }
        public double UsedCredit { get; set; }
        public DateTime CutDate { get; set; }
        public DateTime DueDate { get; set; }
        public short DaysToSpend { get; set; }
        public short DaysToPay { get; set; }
        public string ExpirationDate { get; set; }
        public CardType CardType { get; set; }
        public string EndingCardNumber { get; set; }
        public string Color { get; set; }
    }
}
