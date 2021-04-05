# KafkaProducerConsumer
Brincando de Kafka, partições e paralelizando o processamento

## Comandos bacanas

* Iniciando o Zookeeper: bin/zookeeper-server-start.sh config/zookeeper.properties
* Iniciando o Kafka: bin/kafka-server-start.sh config/server.properties
* Arquivo de configuração: config/server.properties
* Alterar a quantidade de partições do topic: bin/kafka-topics.sh --alter --zookeeper localhost:2181 --topic fila_pedido --partitions 3
* Detalhes dos topics: bin/kafka-topics.sh --bootstrap-server localhost:9092 --describe

## Execução
![Executando o projeto](/images/Kafka-Executando.JPG)
