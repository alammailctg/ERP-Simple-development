using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.FrontEndMvc.Models.SalesOrder;
using AenEnterprise.ServiceImplementations.Implementation;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.InventoryManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IInventoryService _inventoryService;
        private IUnitOfWork _uow;

        public InventoryController(ICategoryService categoryService, 
            IUnitOfWork uow,IInventoryService inventoryService)
        {
            _categoryService = categoryService;
            _uow = uow;
            _inventoryService = inventoryService;
        }
        [HttpGet("AllProducts")]
        public async Task<IActionResult> GetProductAll()
        {
            var productFromService =await _inventoryService.GetAllProducts();
            return Ok(productFromService);
        }


        [HttpGet("GetAll"),Authorize(Roles ="Admin")]
        public async Task<ActionResult> CategoryGetAll()
        {
            var categoryFromRepo =await _categoryService.GetAll();
            return Ok(categoryFromRepo);
        }

        [HttpGet("AllUnits")]
        public async Task<ActionResult> GetUnitAll()
        {
            var unitFromRepo =await _inventoryService.GetAllUnits();
            return Ok(unitFromRepo);
        }
        

        //[HttpGet("GetAllCategory")]
        //public IActionResult GetAllCat()
        //{
        //    var categoryFromRepo = _uow.Category.GetCategoryWithProducts();
        //    return Ok(categoryFromRepo);
        //}
    }
}
