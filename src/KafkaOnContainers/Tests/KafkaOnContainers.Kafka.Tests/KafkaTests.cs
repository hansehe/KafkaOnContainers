using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using FluentAssertions;
using KafkaOnContainers.Kafka.Abstractions;
using KafkaOnContainers.Kafka.TestUtilities;
using Xunit;

namespace KafkaOnContainers.Kafka.Tests
{
    public class KafkaTests
    {
        private static Random Random = new Random();
        
        private static IKafkaConfig GetKafkaConfig()
        {
            return new KafkaConfig
            {
                ProducerConfig =
                {
                    BootstrapServers = TestConfig.KafkaConnectionString
                },
                ConsumerConfig =
                {
                    GroupId = TestConfig.GroupId,
                    BootstrapServers = TestConfig.KafkaConnectionString,
                    AutoOffsetReset = AutoOffsetResetType.Earliest
                }
            };
        }
        
        [Fact]
        public async Task Produce_Consume_Success()
        {
            var kafkaConfig = GetKafkaConfig();
            var producer = new KafkaProducer<Null, string>(kafkaConfig);
            var consumer = new KafkaConsumer<Null, string>(kafkaConfig);

            var topic = $"test-topic-{Random.Next().ToString()}";
            const string value = "testValue";

            consumer.Consumer.Subscribe(topic);
            var deliveryReport = await producer.Producer.ProduceAsync(topic, new Message<Null, string> {Value = value});
            var consumeResult = consumer.Consumer.Consume(TimeSpan.FromSeconds(10));
            consumeResult.Value.Should().Be(value);
        }
    }
}