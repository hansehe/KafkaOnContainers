using System;

namespace KafkaOnContainers.Kafka.TestUtilities
{
    public static class TestConfig
    {
        public static bool InContainer => 
            Environment.GetEnvironmentVariable("RUNNING_IN_CONTAINER") == "true";

        private static string KafkaHostname => InContainer ? "kafka-service" : "localhost";

        private const string KafkaPort = "9092";

        public const string GroupId = "test-consumer-group";
        public static string KafkaConnectionString => $"{KafkaHostname}:{KafkaPort}";
    }
}