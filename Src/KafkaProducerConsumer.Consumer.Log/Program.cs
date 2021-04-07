using Confluent.Kafka;
using System;

namespace KafkaProducerConsumer.Consumer.Log
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumer Log");

            // Consumer Config
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "consumer-log",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumeBuilder = new ConsumerBuilder<string, string>(consumerConfig).Build();
            consumeBuilder.Subscribe("fila_pedido");
            try
            {
                while (true)
                {
                    var message = consumeBuilder.Consume();
                    Console.WriteLine($"Key: {message.Message.Key}, Message: {message.Message.Value} recebida de {message.TopicPartitionOffset}");
                }
            }
            catch (OperationCanceledException)
            {
                consumeBuilder.Close();
            }
        }
    }
}
