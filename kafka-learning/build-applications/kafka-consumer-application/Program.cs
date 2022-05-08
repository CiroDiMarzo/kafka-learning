using Microsoft.Extensions.Configuration;

if (args.Length != 1)
{
    Console.Error.WriteLine("Please provide the configuration file path as a command line argument");
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddIniFile(args[0])
    .Build();

KafkaConsumerApplication kafkaConsumerApplication = new KafkaConsumerApplication(configuration);
kafkaConsumerApplication.Run(new ConsoleWritingRecordsHandler<string, string>());