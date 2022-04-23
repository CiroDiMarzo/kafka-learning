
using Microsoft.Extensions.Configuration;

if (args.Length != 1)
{
    Console.Error.WriteLine("Please provide the configuration file path as a command line argument");
}
else
{
    IConfiguration configuration = new ConfigurationBuilder()
        .AddIniFile(args[0])
        .Build();

    Producer producer = new Producer(configuration);
    producer.Run();

    Consumer consumer = new Consumer(configuration);
    consumer.Run();
}