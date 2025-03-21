using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PubSubCommunication;
using PubSubCommunication.Consumers;
using PubSubCommunication.Messages;
using PubSubCommunication.Publisher;

using PubSubRabbitMQ.Consumer;
using PubSubRabbitMQ.Publisher;
using PubSubRabbitMQ.Serialization;

namespace PubSubRabbitMQ;

public static class RabbitMqExtensions
{
    public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqSettings>(configuration.GetSection("RabbitMqData"));
        //services.AddRabbitMqHealthCheck();
        services.AddTransient<ISerializer, Serializer>();

        return services;
    }

    public static void AddRabbitMqConsumer<TMessage>(this IServiceCollection services)
    {
        services.AddConsumer<TMessage>();
        services.AddSingleton<IMessageConsumer<TMessage>, RabbitMqMessageConsumer<TMessage>>();
    }

    public static void AddRabbitMqPublisher<TMessage>(this IServiceCollection services)
        where TMessage : IMessage
    {
        services.AddPublisher<TMessage>();
        services.AddSingleton<IExternalMessagePublisher<TMessage>, RabbitMqPublisher<TMessage>>();
    }

    // private static void AddRabbitMqHealthCheck(this IServiceCollection services)
    // {
    //     services.AddHealthChecks()
    //     .AddRabbitMQ((serviceProvider, rabbitOptions) =>
    //     {
    //         RabbitMqSettings? settings = serviceProvider.GetRequiredService<IOptions<RabbitMqSettings>>().Value;
    //
    //         rabbitOptions.ConnectionFactory = new ConnectionFactory
    //         {
    //             UserName = settings.Credentials?.Username,
    //             Password = settings.Credentials?.Password,
    //             VirtualHost = "/",
    //             HostName = settings.Hostname,
    //             Port = AmqpTcpEndpoint.UseDefaultPort,
    //         };
    //         rabbitOptions.Connection = rabbitOptions.ConnectionFactory.CreateConnection();
    //     }, string.Empty, HealthStatus.Unhealthy);
    // }


}

