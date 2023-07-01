using Confluent.Kafka;
using WeatherNotifierKafkaConsumer.Slack;

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
        private readonly List<string> topicNames = new List<string>() { "weather" };
        CancellationToken cancellationToken = new CancellationToken();
        Requests slackRequests;
        public Consumer(AuthDetails authDetails)
        {
            consumer = new ConsumerBuilder<Null, string>(config).Build();
            slackRequests = new Requests(authDetails);
        }

        public void getMessages()
        {
            Console.WriteLine("Consumer started");
            consumer.Subscribe(topicNames);

            while (true)
            {
                ConsumeResult<Null, string> consumeResult = consumer.Consume(cancellationToken);
                Notification notification = new Notification(consumeResult.Message.Value.ToString());

                Console.WriteLine("Will send slack notification with text: " + notification.text);
                slackRequests.sendNotification(notification);
            }
        }
    }
}
