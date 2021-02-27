using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aurora.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<MassTransitWorkerHostedService>();
                    services.AddHostedService<Worker>();

                    services.AddMassTransit(busConfigurator =>
                    {
                        busConfigurator.SetKebabCaseEndpointNameFormatter();

                        busConfigurator.AddConsumer<NurturePlanCreatedConsumer>();
                        
                        busConfigurator.UsingRabbitMq((busRegistrationContext, rabbitMqBusFactoryConfigurator) =>
                        {
                            rabbitMqBusFactoryConfigurator.Host("aurora-rabbitmq");

                            rabbitMqBusFactoryConfigurator.ConfigureEndpoints(busRegistrationContext);
                        });
                    });
                });
    }
}
