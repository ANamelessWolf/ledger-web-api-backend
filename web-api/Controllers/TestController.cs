using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nameless.Ledger.Models;
using Nameless.Ledger.ModelsDto;
using Nameless.WebApi.Controllers;
using Nameless.Ledger.BI.Repositories.Implements;
using Nameless.WebApi.Repositories;

namespace Nameless.LedgerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController
        : BasicGenericController<TestRepository, TestModelDto>
    {
        public TestController(IGenericRepository<TestRepository> repository, IMapper mapper) : 
            base(repository, mapper)
        {
        }
    }
}
