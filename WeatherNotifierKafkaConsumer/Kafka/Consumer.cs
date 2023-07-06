using Confluent.Kafka;
using WeatherNotifierKafkaConsumer.Slack;

namespace WeatherNotifierKafkaConsumer.Kafka
{
    public class Consumer
    {
        private IConsumer<Null, string> consumer;
        private List<string> topicNames;
        CancellationToken cancellationToken = new CancellationToken();
        Requests slackRequests;

        public Consumer(AuthDetails authDetails, Config kafkaConfig)
        {
            ConsumerConfig config = new ConsumerConfig
            {
                BootstrapServers = kafkaConfig.server,
                GroupId = kafkaConfig.groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            consumer = new ConsumerBuilder<Null, string>(config).Build();
            slackRequests = new Requests(authDetails);
            topicNames = new List<string>() { kafkaConfig.topic };
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
