using Microsoft.AspNetCore.Mvc;
using Nameless.Ledger.Models;
using Nameless.Ledger.Utils;

namespace Nameless.LedgerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            AppCatalogues appCatalogues = new AppCatalogues();
            appCatalogues.FinancingEntityType = CatalogueUtils.GetFinancingEntityTypeCatalogue();
            return Ok(appCatalogues);
        }
    }
}
