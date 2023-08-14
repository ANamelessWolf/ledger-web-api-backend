using Nameless.Ledger.ModelTypes;
using Nameless.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.ModelsDto
{
    public class CreditCardDto : BaseDto
    {
        public int FinancingEntityId { get; set; }
        public string? Name { get; set; }
        public string ShortName { get; set; }
        public double CreditValue { get; set; }
        public string? Credit { get; set; }
        public double UsedCreditValue { get; set; }
        public string? UsedCredit { get; set; }
        public int ClosingDay { get; set; }
        public int DueDay { get; set; }
        public string ExpirationDate { get; set; }
        public string? CardType { get; set; }
        public int? CardTypeId { get; set; }
        public string Color { get; set; }
        public string EndingCardNumber { get; set; }

        //public int? FinancingEntityId { get; set; }
        //public string? Name { get; set; }
        //public string? ShortName { get; set; }
        //public double? CreditValue { get; set; }
        //public double? UsedCreditValue { get; set; }
        //public int? ClosingDay { get; set; }
        //public int? DueDay { get; set; }
        //public string? ExpirationDate { get; set; }
        //public int? CardTypeId { get; set; }
        //public string? Color { get; set; }
        //public string? EndingCardNumber { get; set; }
    }
}
