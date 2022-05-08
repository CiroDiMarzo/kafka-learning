using Microsoft.Extensions.Configuration;

namespace KafkaProducerApplicationCSharp.ProducerApplication;

class Program
{
    public static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            throw new ArgumentException($"Missing configuration file path argument.");
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddIniFile(args[0])
            .Build();

        int count = 0;
        int partitionCount = 6;
        string topicName = "input-topic";
        int key = 0;
        string? message = string.Empty;

        do
        {
            System.Console.WriteLine("Write a message to the topic ");
            message = Console.ReadLine();

            if (message != null && message.Length > 0)
            {
                ProducerApplication<string, string> producerApplication = new ProducerApplication<string, string>(configuration);

                producerApplication.SendMessage(topicName, ((count++) % partitionCount).ToString(), message);
            }

        } while (message.Length > 0);
    }
}
