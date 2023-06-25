using Confluent.Kafka;

namespace WeatherNotifierKafkaConsumer.Kafka
{
    public class Consumer
    {
        ConsumerConfig config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "Weather-Consumer",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        private IConsumer<Null, string> consumer;
        private readonly List<string> topicNames = new List<string>() { "test" };
        CancellationToken cancellationToken = new CancellationToken();

        public Consumer()
        {
            consumer = new ConsumerBuilder<Null, string>(config).Build();
        }

        public void getMessages()
        {
            consumer.Subscribe(topicNames);

            while (true)
            {
                ConsumeResult<Null, string> consumeResult = consumer.Consume(cancellationToken);

                //todo: implement the part that handles the result
            }
        }
    }
}
