using Confluent.Kafka;
using KafkaFlow;
using VHub.Media.Application.Contracts.Movies.Events;

namespace VHub.Media.Application.Movies.Producers;

public class MovieCreatedProducer(IMessageProducer<MovieCreatedProducer> producer) : IMovieCreatedProducer
{
    private readonly IMessageProducer<MovieCreatedProducer> _producer =
        producer ?? throw new ArgumentNullException(nameof(producer));

    public async Task SendMovieCreatedEvent(MovieCreatedEvent movieCreatedEvent, CancellationToken cancellationToken)
    {
        try
        {
            var deliveryResult = await _producer.ProduceAsync(messageKey: null, movieCreatedEvent);

            Console.WriteLine($"Movie event delivered to: {deliveryResult.TopicPartitionOffset}");
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            throw;
        }
    }
}