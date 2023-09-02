using Nameless.WebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nameless.Ledger.Models
{
    public class SubCategory : DbModel
    {
        [Column("idSubCategory")]
        public new int Id { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Name { get; set; }
    }
}
