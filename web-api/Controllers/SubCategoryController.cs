using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nameless.Ledger.BI.Repositories.Implements;
using Nameless.Ledger.Models;
using Nameless.Ledger.ModelsDto;
using Nameless.WebApi.Controllers;

namespace Nameless.LedgerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController
        : GenericController<SubCategory, SubCategoryDto, NewSubCategoryDto>
    {
        public SubCategoryController(SubCategoryRepository repository, IMapper mapper) : 
            base(repository, mapper)
        {
        
        }

    }
}
