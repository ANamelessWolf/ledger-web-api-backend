using Nameless.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.ModelsDto
{
    public class FinancingEntityDto : BaseDto
    {
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? FinancingType { get; set; }
    }
}
