using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nameless.Ledger.BI.Repositories.Implements;
using Nameless.Ledger.Models;
using Nameless.Ledger.ModelTypes;
using Nameless.Ledger.Utils;
using Nameless.WebApi.Models;

namespace Nameless.LedgerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : Controller
    {
        public FinancingEntityRepository FinanEntRepo { get; }
        public CreditCardRepository CCardRepo { get; }

        public CatalogueController(FinancingEntityRepository _finanEntRepo, CreditCardRepository _cCCardRepo, IMapper mapper) 
        {
            this.FinanEntRepo = _finanEntRepo;
            this.CCardRepo = _cCCardRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            AppCatalogues appCatalogues = new AppCatalogues();
            appCatalogues.FinancingEntityType = CatalogueUtils.GetFinancingEntityTypeCatalogue();
            appCatalogues.CardType = CatalogueUtils.GetCardTypeCatalogue();
            var fiEnCat = await this.FinanEntRepo.GetAll();
            appCatalogues.FinancingEntity = fiEnCat.Select(x => new CatalogueItem() { Id = x.Id, Description = x.Name ?? "" }).ToArray();
            var cCardCat = await this.CCardRepo.GetAll();
            appCatalogues.CreditCard = cCardCat.Select(x => new CatalogueItem() { Id = x.Id, Description = x.ShortName ?? "" }).ToArray();
            return Ok(appCatalogues);
        }
    }
}
