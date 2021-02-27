using System.Threading.Tasks;
using Aurora.Integration.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Aurora.Worker
{
    public class NurturePlanCreatedConsumer : IConsumer<INurturePlanCreated>
    {
        private readonly ILogger<NurturePlanCreatedConsumer> logger;

        public NurturePlanCreatedConsumer(ILogger<NurturePlanCreatedConsumer> logger)
        {   
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<INurturePlanCreated> context)
        {
            var message = context.Message;

            logger.LogInformation($"Nurture plan {message.NurturePlanId} was created for an organization {message.OrganizationId}");
            
            return Task.CompletedTask;
        }
    }
}