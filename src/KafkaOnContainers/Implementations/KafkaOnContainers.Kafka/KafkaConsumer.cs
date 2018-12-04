using Confluent.Kafka;
using KafkaOnContainers.Kafka.Abstractions;

namespace KafkaOnContainers.Kafka
{
    public class KafkaConsumer<TKey, TValue> : IKafkaConsumer<TKey, TValue>
    {
        public IConsumer<TKey, TValue> Consumer { get; }
        
        public KafkaConsumer(IKafkaConfig kafkaConfig)
        {
            Consumer = new Consumer<TKey, TValue>(kafkaConfig.ConsumerConfig);
        }

        public void Dispose()
        {
            Consumer?.Dispose();
        }
    }
}