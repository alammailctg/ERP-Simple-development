using AenEnterprise.ServiceImplementations.Implementation.AccountsService;
using AenEnterprise.ServiceImplementations.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/AccountPayable")]
    [ApiController]
    public class AccountPayableController : ControllerBase
    {
        private readonly IAccountPayableService _accountPayableService;
        public AccountPayableController(IAccountPayableService accountPayableService)
        {
            _accountPayableService = accountPayableService;
        }
    }
}
