﻿using Confluent.Kafka;
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
        private readonly List<string> topicNames = new List<string>() { "test" };
        CancellationToken cancellationToken = new CancellationToken();
        AuthDetails authDetails;
        Requests slackRequests;

        public Consumer()
        {
            consumer = new ConsumerBuilder<Null, string>(config).Build();
            authDetails = new AuthDetails();
            slackRequests = new Requests(authDetails);
        }

        public void getMessages()
        {
            consumer.Subscribe(topicNames);

            while (true)
            {
                ConsumeResult<Null, string> consumeResult = consumer.Consume(cancellationToken);
                Notification notification = new Notification(consumeResult.Message.Value.ToString());
                slackRequests.sendNotification(notification);
            }
        }
    }
}
