using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

public class KafkaConsumerApplication
{
    private readonly IConfiguration _configuration;

    public KafkaConsumerApplication(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public void Run(IConsumerRecordsaHandler<string, string> consumerRecordsaHandler)
    {

        CancellationTokenSource cts = new CancellationTokenSource();
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true; // prevent the process from terminating.
            cts.Cancel();
        };

        using (IConsumer<string, string> consumer = new ConsumerBuilder<string, string>(this._configuration.AsEnumerable()).Build())
        {
            consumer.Subscribe("input-topic");
            try
            {
                while (true)
                {
                    ConsumeResult<string, string> result = consumer.Consume(cts.Token);
                    consumerRecordsaHandler.Process(result);
                }
            }
            catch (OperationCanceledException)
            {
                // CTRL+C was pressed
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}