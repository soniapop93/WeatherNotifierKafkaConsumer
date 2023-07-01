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
        
        
        AuthDetails authDetails = new AuthDetails();
        authDetails.channelId = "";
        authDetails.endpoint = "https://slack.com/api/chat.postMessage";
        authDetails.token = "";

        Consumer consumer = new Consumer(authDetails);

        consumer.getMessages();
    }
}