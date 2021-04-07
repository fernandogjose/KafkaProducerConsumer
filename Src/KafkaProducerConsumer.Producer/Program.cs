using Confluent.Kafka;
using RestSharp;
using System;

namespace KafkaProducerConsumer.Producer.Pedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Call API and Producer for Kafka");
            var readKeyUser = "1";
            while (readKeyUser == "1")
            {
                // Busca os dados da API
                var client = new RestClient("https://api.awsli.com.br/v1/cliente?format=json&chave_aplicacao=2ccd148c-4546-4fee-b66e-8e94e46b961e&limit=20&offset=0&chave_api=97543c6dd0d6802fc0e3");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                IRestResponse response = client.Execute(request);

                // Validar se retornou com sucesso

                // Producer
                for (int i = 0; i < 50; i++)
                {
                    var SendMessageByKafkaResponse = SendMessageByKafka($"{1}-{DateTime.Now:dd-MM-yyyy--mmss}", response.Content);
                    Console.WriteLine($"Mensagem enviada com sucesso - {SendMessageByKafkaResponse}");
                }

                Console.WriteLine("Rodar novamente");
                Console.WriteLine("1 = sim");
                Console.WriteLine("2 = não");
                readKeyUser = Console.ReadLine();
            }
        }

        private static string SendMessageByKafka(string key, string message)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                try
                {
                    var sendResult = producer.ProduceAsync("fila_pedido", new Message<string, string> { Key = key, Value = message }).GetAwaiter().GetResult();
                    return $"{sendResult.TopicPartitionOffset}";
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
