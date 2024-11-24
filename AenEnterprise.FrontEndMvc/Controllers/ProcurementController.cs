using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    public class ProcurementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePurchaseOrder()
        {
            return View();
        }
    }
}
