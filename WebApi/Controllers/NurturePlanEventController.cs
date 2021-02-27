using System;
using System.Threading.Tasks;
using Aurora.Integration.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Aurora.WebApi.Controllers 
{
    [ApiController]
    [Route("api/organization/{organizationId}/nurtureplan/{nurturePlanId}/event")]    
    public class NurturePlanEventController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;

        public NurturePlanEventController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        [HttpPost("created")]
        public async Task<IActionResult> Created(Guid organizationId, Guid nurturePlanId)
        {
            await publishEndpoint.Publish<INurturePlanCreated>(new
            {
                OrganizationId = organizationId,
                NurturePlanId = nurturePlanId
            });

            return NoContent();
        }
    }
}