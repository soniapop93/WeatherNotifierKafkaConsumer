using System.Text.Json;
using WeatherNotifierKafkaConsumer.Weather;

namespace WeatherNotifierKafkaConsumer.Slack
{
    public class Notification
    {
        public string text { get; set; }
        Forecast forecast;

        public Notification(string text)
        {
            this.text = parseJson(text);
        }

        private string parseJson(string text)
        {
            forecast = JsonSerializer.Deserialize<Forecast>(text);

            string notificationText = String.Format("Precipitation probability at {0} is: {1}", forecast.timestamp.ToString("dd-MM-yyyy HH:mm:ss"), forecast.probability.ToString());
            return notificationText;
        }
    }
}
