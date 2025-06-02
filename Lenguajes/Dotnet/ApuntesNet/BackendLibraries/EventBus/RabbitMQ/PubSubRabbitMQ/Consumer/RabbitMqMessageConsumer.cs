using System.Diagnostics;
using Microsoft.Extensions.Options;
using PubSubCommunication.Consumers;
using PubSubCommunication.Consumers.Handler;
using PubSubCommunication.Messages;
using PubSubRabbitMQ.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PubSubRabbitMQ.Consumer;

public class RabbitMqMessageConsumer<TMessage> : IMessageConsumer<TMessage>
{
    private readonly RabbitMqSettings _rabbitMqSettings;
    private readonly IConnectionFactory _connectionFactory;
    private readonly IHandleMessage _handleMessage;
    private readonly ISerializer _serializer;

    private bool disposed;
    private IConnection? connection;
    private IModel? channel;

    public RabbitMqMessageConsumer(
        IHandleMessage handleMessage,
        IOptions<RabbitMqSettings> rabbitMqSettings,
        ISerializer serializer
    )
    {
        _handleMessage = handleMessage;
        _rabbitMqSettings = rabbitMqSettings.Value;

        _connectionFactory = new ConnectionFactory
        {
            HostName = rabbitMqSettings.Value.Hostname,
            Password = rabbitMqSettings.Value.Credentials!.Password,
            UserName = rabbitMqSettings.Value.Credentials!.Username,
            DispatchConsumersAsync = true,
        };
        _serializer = serializer;
    }

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        connection = _connectionFactory.CreateConnection();
        channel = connection.CreateModel();

        return Consume();
    }

    private Task Consume()
    {
        AsyncEventingBasicConsumer? asyncReceiver = new(channel);
        asyncReceiver.Received += HandleMessage;

        string? queue = GetCorrectQueue();
        channel.BasicQos(0, 10, false);
        channel.BasicConsume(queue, false, asyncReceiver);
        return Task.CompletedTask;
    }

    private string GetCorrectQueue()
    {
        return (
                typeof(TMessage) == typeof(IntegrationMessage)
                    ? _rabbitMqSettings.Consumer?.IntegrationQueue
                    : _rabbitMqSettings.Consumer?.DomainQueue
            ) ?? throw new ArgumentException("please configure the queues on the appsettings");
    }

    private async Task HandleMessage(object ch, BasicDeliverEventArgs eventArgs)
    {
        Type? messageType = Type.GetType(eventArgs.BasicProperties.Type)!;
        byte[]? messageBody = eventArgs.Body.ToArray()!;
        ulong deliveryTag = eventArgs.DeliveryTag;

        IMessage? message =
            _serializer.DeserializeObject(messageBody, messageType) as IMessage
            ?? throw new ArgumentException("The message did not deserialized properly");

        await _handleMessage.Handle(message, CancellationToken.None);

        ActivityTraceId traceId = default;
        if (!string.IsNullOrEmpty(message?.Traces?.TraceId))
        {
            traceId = ActivityTraceId.CreateFromString(message.Traces.TraceId);
        }

        ActivitySpanId spanId = default;
        if (!string.IsNullOrEmpty(message?.Traces?.SpanId))
        {
            spanId = ActivitySpanId.CreateFromString(message.Traces.SpanId);
        }

        using ActivitySource? tracingConsumer = new(nameof(IMessageHandler));
        using Activity? activity = tracingConsumer.CreateActivity(
            "Call ACK",
            ActivityKind.Consumer
        );
        activity?.SetParentId(traceId, spanId, ActivityTraceFlags.Recorded);
        activity?.Start();
        ((AsyncEventingBasicConsumer)ch).Model.BasicAck(deliveryTag, false);
        activity?.SetStatus(ActivityStatusCode.Ok);

        await Task.Yield();
    }

    public void Dispose()
    {
        if (!disposed)
        {
            connection.Dispose();
            channel.Dispose();
            disposed = true;

            GC.SuppressFinalize(this);
        }
    }
}
