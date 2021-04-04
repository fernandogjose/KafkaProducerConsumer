using Confluent.Kafka;
using System;
using System.Threading;

namespace KafkaProducerConsumer.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumer 1");

            // Consumer Config
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var c = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                c.Subscribe("fila_pedido");
                var cts = new CancellationTokenSource();

                try
                {
                    while (true)
                    {
                        var message = c.Consume(cts.Token);
                        Console.WriteLine($"Key: {message.Message.Key}, Message: {message.Message.Value} recebida de {message.TopicPartitionOffset}");
                    }
                }
                catch (OperationCanceledException operationCanceledException)
                {
                    c.Close();
                }
            }
        }
    }
}
