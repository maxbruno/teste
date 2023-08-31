using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Application.Services;
using Bank.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<AccountViewModel>> GetAll([FromQuery] AccountFilterViewModel filter)
        {
            return Ok(_accountAppService.GetAll(filter));
        }
        
        [HttpGet("transactions/{accountId}")]
        public async Task<ActionResult<IEnumerable<TransactionViewModel>>> GetById([FromQuery]AccountIdViewModel account)
        {
            var transactionViewModel  = await _accountAppService.GetByAccountId(account.AccountId);

            if (!transactionViewModel.Any()) return NotFound();

            return Ok(transactionViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionViewModel>> Post([FromBody]TransactionInputViewModel transaction)
        {
            if (transaction == null) return NotFound();

            var transactionViewModel = await _accountAppService.Transaction(transaction);
            
            return Created(nameof(GetById), new AccountIdViewModel(transactionViewModel.AccountId));
        }
    }
}