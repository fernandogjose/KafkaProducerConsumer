using Confluent.Kafka;
using System;

namespace KafkaProducerConsumer.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Producer");

            var readKeyUser = "1";
            while (readKeyUser == "1")
            {
                for (int i = 0; i < 50; i++)
                {
                    var SendMessageByKafkaResponse = SendMessageByKafka($"minha mensagem {i}");
                    Console.WriteLine($"Mensagem enviada com sucesso - {SendMessageByKafkaResponse}");
                }

                Console.WriteLine("Rodar novamente");
                Console.WriteLine("1 = sim");
                Console.WriteLine("2 = não");
                readKeyUser = Console.ReadLine();
            }
        }

        private static string SendMessageByKafka(string message)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                try
                {
                    var sendResult = producer.ProduceAsync("fila_pedido", new Message<string, string> { Key = message, Value = message }).GetAwaiter().GetResult();
                    return $"Mensagem '{sendResult.Value}' de '{sendResult.TopicPartitionOffset}'";
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }

            return string.Empty;
        }
    }
}
