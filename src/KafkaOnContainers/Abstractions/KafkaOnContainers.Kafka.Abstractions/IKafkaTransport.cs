using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Rebus.Bus;
using Rebus.Subscriptions;
using Rebus.Transport;

namespace KafkaOnContainers.Kafka.Abstractions
{
    public interface IKafkaTransport : ITransport, IDisposable, IInitializable, ISubscriptionStorage
    {
        IKafkaConfig KafkaConfig { get; }

        Task Publish<TKey, TValue>(Message<TKey, TValue> message, string topic);
        
        Task Subscribe<TKey, TValue>(string topic);
    }
}