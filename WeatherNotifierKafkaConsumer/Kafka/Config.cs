namespace WeatherNotifierKafkaConsumer.Kafka
{
    public class Config
    {
        public string server { get; set; }
        public string topic { get; set; }
        public string groupId { get; set; }
        public string token { get; set; }
        public string channelId { get; set; }
    }
}
