using Nameless.WebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nameless.Ledger.Models
{
    public class Category : DbModel
    {
        [Column("idCategory")]
        public new int Id { get; set; }
        public string? Name { get; set; }
    }
}
