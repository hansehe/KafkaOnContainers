using Confluent.Kafka;
using KafkaOnContainers.Kafka.Abstractions;

namespace KafkaOnContainers.Kafka
{
    public class KafkaProducer<TKey, TValue> : IKafkaProducer<TKey, TValue>
    {
        public IProducer<TKey, TValue> Producer { get; }
        
        public KafkaProducer(IKafkaConfig kafkaConfig)
        {
            Producer = new Producer<TKey, TValue>(kafkaConfig.ProducerConfig);
        }

        public void Dispose()
        {
            Producer?.Dispose();
        }
    }
}