using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.MessageBroker;

public static class RabbitExtension
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitSettings = configuration.GetSection("MessageBroker").Get<MessageBrokerSettings>();

        try
        {
            services.AddMassTransit(busConfigurator =>
            {
                //busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitSettings.Host, h =>
                    {
                        h.Username(rabbitSettings.Username);
                        h.Password(rabbitSettings.Password);
                    });

                    //cfg.ConfigureEndpoints(context);
                });
            });
        }
        catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException ex)
        {
            Console.WriteLine("Cannot reach RabbitMQ broker. Exception: " + ex.Message);
        }
        catch (RabbitMQ.Client.Exceptions.OperationInterruptedException ex)
        {
            Console.WriteLine("Operation interrupted: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        return services;
    }
}