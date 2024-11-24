using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/Cache")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _redisDb;
        public CacheController(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }

        public async Task<IActionResult> SetSalesOrderId([FromBody] string salesOrderId)
        {
            await _redisDb.StringSetAsync("SalesOrderId", salesOrderId, TimeSpan.FromMinutes(30));
            return Ok("SalesOrderId set in Redis");
        }

        [Route("GetSalesOrder")]
        [HttpGet]
        public async Task<IActionResult> GetSalesOrderId()
        {
           var SalesOrderId= await _redisDb.StringGetAsync("SalesOrderId");
            if(SalesOrderId.IsNullOrEmpty)
            {
                return NotFound("SalesOrderId does not found!");
            }
            return Ok(SalesOrderId);
        }

        public async Task<IActionResult> RemoveSalesOrderId()
        {
            await _redisDb.KeyDeleteAsync("SalesOrderId");
            return Ok("SalesOrderId Removed");
        }
    }
}
