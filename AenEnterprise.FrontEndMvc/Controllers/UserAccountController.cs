
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    
    public class UserAccountController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AssignRole()
        {
            return View();
        }
    }
}
