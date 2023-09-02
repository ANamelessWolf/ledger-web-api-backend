using Nameless.WebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nameless.Ledger.Models
{
    public class Vendor : DbModel
    {
        [Column("idVendor")]
        public new int Id { get; set; }
        public string? Name { get; set; }
    }
}
