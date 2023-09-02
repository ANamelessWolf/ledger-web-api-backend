using Nameless.WebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nameless.Ledger.ModelsDto
{
    public class NewSubCategoryDto
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
    }
}
