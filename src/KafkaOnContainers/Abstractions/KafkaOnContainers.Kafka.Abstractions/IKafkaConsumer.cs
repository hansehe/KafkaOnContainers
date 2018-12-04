using System;
using Confluent.Kafka;

namespace KafkaOnContainers.Kafka.Abstractions
{
    public interface IKafkaConsumer<TKey, TValue> : IDisposable
    {
        IConsumer<TKey, TValue> Consumer { get; }
    }
}