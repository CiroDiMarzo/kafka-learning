using Microsoft.Extensions.Configuration;

public class TopologyBuilder
{
    private readonly IConfiguration _configuration;

    public TopologyBuilder(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public void Build(string inputTopic, string outputTopic)
    {
        // Kafka Streams not supported in C#
    }
}