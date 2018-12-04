using System;
using Confluent.Kafka;

namespace KafkaOnContainers.Kafka.Abstractions
{
    public interface IKafkaProducer<TKey, TValue> : IDisposable
    {
        IProducer<TKey, TValue> Producer { get; }
    }
}