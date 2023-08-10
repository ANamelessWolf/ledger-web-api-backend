using Nameless.WebApi.Models;

namespace Nameless.Ledger.ModelsDto
{
    public class NewFinancingEntityDto 
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int FinancingType { get; set; }
    }
}
