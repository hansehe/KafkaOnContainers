using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using KafkaOnContainers.Kafka.Abstractions;
using Rebus.Messages;
using Rebus.Transport;

namespace KafkaOnContainers.Kafka
{
    public class KafkaTransport : IKafkaTransport
    {
        private ConcurrentDictionary<string, object> Producers = new ConcurrentDictionary<string, object>();
        private ConcurrentDictionary<string, object> Consumers = new ConcurrentDictionary<string, object>();
        
        public KafkaTransport(IKafkaConfig kafkaConfig)
        {
            KafkaConfig = kafkaConfig;
        }

        public IKafkaConfig KafkaConfig { get; }
        
        public Task Publish<TKey, TValue>(Message<TKey, TValue> message, string topic)
        {
            var producer = (IKafkaProducer<TKey, TValue>) Producers.GetOrAdd(topic, new KafkaProducer<TKey, TValue>(KafkaConfig));
            return producer.Producer.ProduceAsync(topic, message);
        }

        public Task Subscribe<TKey, TValue>(string topic)
        {
            var consumer = (IKafkaConsumer<TKey, TValue>) Consumers.GetOrAdd(topic, InitializeConsumer(new KafkaConsumer<TKey, TValue>(KafkaConfig)));
            consumer.Consumer.Subscribe(topic);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void CreateQueue(string address)
        {
            throw new System.NotImplementedException();
        }

        public Task Send(string destinationAddress, TransportMessage message, ITransactionContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task<TransportMessage> Receive(ITransactionContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public string Address { get; }
        
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public Task<string[]> GetSubscriberAddresses(string topic)
        {
            throw new System.NotImplementedException();
        }

        public Task RegisterSubscriber(string topic, string subscriberAddress)
        {
            throw new System.NotImplementedException();
        }

        public Task UnregisterSubscriber(string topic, string subscriberAddress)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCentralized { get; }

        private static IKafkaConsumer<TKey, TValue> InitializeConsumer<TKey, TValue>(IKafkaConsumer<TKey, TValue> consumer)
        {
            var cancelToken = new CancellationToken();
            while (true)
            {
                var consumeResult = consumer.Consumer.Consume(cancelToken);
            }
        }
    }
}