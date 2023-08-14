using Nameless.Ledger.ModelTypes;
using Nameless.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.Models
{
    public class CreditCard : DbModel
    {
        [Column("idTarjetaCredito")]
        public new int Id { get; set; }
        public int FinancingEntityId { get; set; }
        public string? Name { get; set; }
        public string ShortName { get; set; }
        public double Credit { get; set; }
        public double UsedCredit { get; set; }
        public int ClosingDay { get; set; }
        public int DueDay { get; set; }
        public string ExpirationDate { get; set; }
        public CardType CardType { get; set; }
        public string Color { get; set; }
        public string EndingCardNumber { get; set; }
    }
}
