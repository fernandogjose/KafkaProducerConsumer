using Confluent.Kafka;
using System;

namespace KafkaProducerConsumer.Consumer.Pedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumer Pedido");

            // Consumer Config
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "consumer-pedido",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumerBuilder = new ConsumerBuilder<string, string>(consumerConfig).Build();
            consumerBuilder.Subscribe("fila_pedido");
            try
            {
                while (true)
                {
                    var message = consumerBuilder.Consume();
                    //Console.WriteLine($"Key: {message.Message.Key}, Message: {message.Message.Value} recebida de {message.TopicPartitionOffset}");
                    Console.WriteLine($"Key: {message.Message.Key}, recebida de {message.TopicPartitionOffset}");
                }
            }
            catch (OperationCanceledException)
            {
                consumerBuilder.Close();
            }
        }
    }
}
