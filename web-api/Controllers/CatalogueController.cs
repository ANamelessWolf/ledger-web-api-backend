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
        public CategoryRepository CatRepo { get; }
        public SubCategoryRepository SubCatRepo { get; }
        public VendorRepository VendorRepo { get; }

        public CatalogueController(FinancingEntityRepository _finanEntRepo, CreditCardRepository _cCCardRepo, 
            CategoryRepository _catCRepo, SubCategoryRepository _subRepo, VendorRepository _vendorRepo, IMapper mapper) 
        {
            this.FinanEntRepo = _finanEntRepo;
            this.CCardRepo = _cCCardRepo;
            this.CatRepo = _catCRepo;
            this.SubCatRepo = _subRepo;
            this.VendorRepo = _vendorRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            AppCatalogues appCatalogues = new AppCatalogues();
            appCatalogues.FinancingEntityType = CatalogueUtils.GetFinancingEntityTypeCatalogue();
            appCatalogues.CardType = CatalogueUtils.GetCardTypeCatalogue();
            var fiEnCat = await this.FinanEntRepo.GetAll();
            appCatalogues.FinancingEntity = fiEnCat.Select(x => new CatalogueItem() { Id = x.Id, Description = x.Name ?? "" }).OrderBy(x=>x.Description).ToArray();
            var cCardCat = await this.CCardRepo.GetAll();
            appCatalogues.CreditCard = cCardCat.Select(x => new CatalogueItem() { Id = x.Id, Description = x.ShortName ?? "" }).OrderBy(x => x.Description).ToArray();
            var catCat = await this.CatRepo.GetAll();
            appCatalogues.Category = catCat.Select(x => new CatalogueItem() { Id = x.Id, Description = x.Name ?? "" }).OrderBy(x => x.Description).ToArray();
            var subCat = await this.SubCatRepo.GetAll();
            appCatalogues.SubCategory = subCat.Select(x => new CatalogueItem() { Id = x.Id, Description = x.Name ?? "" }).OrderBy(x => x.Description).ToArray();
            var vendorCat = await this.VendorRepo.GetAll();
            appCatalogues.Vendor = vendorCat.Select(x => new CatalogueItem() { Id = x.Id, Description = x.Name ?? "" }).OrderBy(x => x.Description).ToArray();
            return Ok(appCatalogues);
        }
    }
}
