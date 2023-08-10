using Nameless.Ledger.ModelTypes;
using Nameless.WebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nameless.Ledger.Models
{
    /// <summary>
    /// A financing entity is the party in a financial transaction that provides money, 
    /// property, or another asset to an intermediary or financed entity
    /// </summary>
    public class FinancingEntity : DbModel
    {
        [Column("idEntidad")]
        public new int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public FinancingEntityType FinancingType { get; set; }
    }
}
