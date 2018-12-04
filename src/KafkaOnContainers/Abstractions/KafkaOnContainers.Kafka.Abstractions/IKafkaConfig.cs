using Confluent.Kafka;

namespace KafkaOnContainers.Kafka.Abstractions
{
    public interface IKafkaConfig
    {
        ProducerConfig ProducerConfig { get; }
        
        ConsumerConfig ConsumerConfig { get; }
    }
}