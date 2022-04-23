using Confluent.Kafka;

public interface IConsumerRecordsaHandler<K, V>
{
    void Process(ConsumeResult<K, V> consumerRecords);
}