using Confluent.Kafka;

public class ConsoleWritingRecordsHandler<K, V> : IConsumerRecordsaHandler<K, V>
{
    public void Process(ConsumeResult<K, V> consumerRecords)
    {
        System.Console.WriteLine($"Key: {consumerRecords.Message.Key}, Value: {consumerRecords.Message.Value}");
    }
}