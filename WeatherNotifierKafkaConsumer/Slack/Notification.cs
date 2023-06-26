namespace WeatherNotifierKafkaConsumer.Slack
{
    public class Notification
    {
        public string text { get; set; }

        public Notification(string text)
        {
            this.text = text;
        }
    }
}
