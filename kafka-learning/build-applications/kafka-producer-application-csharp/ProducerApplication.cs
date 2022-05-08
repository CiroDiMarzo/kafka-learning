using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace KafkaProducerApplicationCSharp.ProducerApplication;

public class ProducerApplication<TKey, TValue>
{
    private readonly IConfiguration _configuration;

    public ProducerApplication(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public void SendMessage(string topic, TKey key, TValue message)
    {
        using (IProducer<TKey, TValue> producer = new ProducerBuilder<TKey, TValue>(this._configuration.AsEnumerable()).Build())
        {
            try
            {
                producer.Produce(topic, new Message<TKey, TValue>() { Key = key, Value = message }, (report) =>
                {
                    System.Console.WriteLine($"Message sent \"{report.Message.Value}\" to partition {report.Partition.Value} at offset {report.Offset.ToString()}");
                });
            }
            catch (ProduceException<TKey, TValue> produceException)
            {
                System.Console.WriteLine($"An exception has occurred {produceException.ToString()}");
            }
            catch (Exception exception)
            {
                System.Console.WriteLine($"An exception has occurred {exception.ToString()}");
            }
            finally
            {
                producer.Flush();
            }
        }
    }
}