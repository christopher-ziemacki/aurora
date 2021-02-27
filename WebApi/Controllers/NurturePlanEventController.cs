using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aurora.WebApi.Controllers 
{
    [ApiController]
    [Route("api/organization/{organizationId}/nurtureplan/{nurturePlanId}/event")]    
    internal class NurturePlanEventController : ControllerBase
    {
        public NurturePlanEventController()
        {
            
        }

        [HttpPost("created")]
        public async Task<IActionResult> Created(Guid organizationId, Guid nurturePlanId)
        {
            return Ok("nurture plan created");
        }
    }
}