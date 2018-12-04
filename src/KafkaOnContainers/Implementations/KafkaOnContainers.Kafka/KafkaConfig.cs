using Confluent.Kafka;
using KafkaOnContainers.Kafka.Abstractions;

namespace KafkaOnContainers.Kafka
{
    public class KafkaConfig : IKafkaConfig
    {
        public ProducerConfig ProducerConfig { get; } = new ProducerConfig();
        public ConsumerConfig ConsumerConfig { get; } = new ConsumerConfig();
    }
}