using Nameless.WebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nameless.Ledger.ModelsDto
{
    public class VendorDto :  BaseDto
    {
        public string? Name { get; set; }
    }
}
