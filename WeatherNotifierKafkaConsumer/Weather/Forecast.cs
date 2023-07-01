namespace WeatherNotifierKafkaConsumer.Weather
{
    public class Forecast
    {
        public DateTime timestamp { get; set; }
        public int probability { get; set; }
    }
}
