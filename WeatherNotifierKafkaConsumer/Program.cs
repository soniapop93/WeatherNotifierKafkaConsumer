using System.Text.Json;
using WeatherNotifierKafkaConsumer.Kafka;
using WeatherNotifierKafkaConsumer.Slack;

public class Program
{
    public static async Task Main(string[] args)
    {
        /*
           =============================================================
           =============================================================
              The API endoints used in this script are free to use.
              https://ipinfo.io/ip
              https://api.techniknews.net/ipgeo/ + ipAddress
              https://api.open-meteo.com/

            Kafka Consumer:
                - consumes data from Producer WeatherNotifierKafkaProducer
                - sends a slack message that the precipitation probability changed

           =============================================================
           =============================================================
        */

        Config kafkaConfig = JsonSerializer.Deserialize<Config>(File.ReadAllText("kafka_config.json"));

        AuthDetails authDetails = new AuthDetails();
        authDetails.channelId = kafkaConfig.channelId;
        authDetails.endpoint = "https://slack.com/api/chat.postMessage";
        authDetails.token = kafkaConfig.token;

        Consumer consumer = new Consumer(authDetails, kafkaConfig);

        consumer.getMessages();
    }
}