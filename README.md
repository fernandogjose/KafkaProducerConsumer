# KafkaProducerConsumer
Brincando de Kafka, partições e paralelizando o processamento

## Comandos bacanas

* Iniciando o Zookeeper: bin/zookeeper-server-start.sh config/zookeeper.properties
* Iniciando o Kafka: bin/kafka-server-start.sh config/server.properties
* Arquivo de configuração: config/server.properties
* Alterar a quantidade de partições do topic: bin/kafka-topics.sh --alter --zookeeper localhost:2181 --topic fila_pedido --partitions 3
* Detalhes dos topics: bin/kafka-topics.sh --bootstrap-server localhost:9092 --describe

## Passos para replicar
1.0 Crie um novo config/server-properties
2.0 Mudar o broker.id
3.0 Mudar a porta (PLAINTEXT://:XXXX)
4.0 Mudar o diretório: log.dirs
5.0 Mudar o __consumer_offset
5.1 default.replication.factor=3
5.2 offsets.topic.replication.factor=3
5.3 transaction.state.log.replication.factor=3

## Execução
![Executando o projeto](https://github.com/fernandogjose/KafkaProducerConsumer/blob/main/Images/Kafka-Executando.JPG)
