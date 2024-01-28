using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nameless.Ledger.BI.Repositories.Implements;
using Nameless.Ledger.Models;
using Nameless.Ledger.ModelsDto;
using Nameless.WebApi.Controllers;
using System.Net;
using System.Reflection;

namespace Nameless.LedgerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController
        : GenericController<CreditCard, CreditCardDto, NewCreditCardDto>
    {

        CreditCardOverviewRepository OverviewRepository { get; set; }

        public CreditCardController(CreditCardRepository repository, CreditCardOverviewRepository overviewRepository,
            IMapper mapper) : 
            base(repository, mapper)
        {
            this.OverviewRepository = overviewRepository;
        }

        /// <summary>
        /// Get the credit card overview
        /// </summary>
        /// <returns>A list of the current objects</returns>
        /// <response code="200">The list of items</response>
        [HttpGet]
        [Route("[action]/")]
        public async Task<IActionResult> Overview()
        {
            var result = await this.OverviewRepository.GetAll();
            return Ok(result);
        }

    }
}
