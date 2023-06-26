using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WeatherNotifierKafkaConsumer.Slack
{
    public class Requests
    {
        private Notification notification;

        public Requests(Notification notification)
        {
            this.notification = notification;
        }

        public void sendNotification()
        {

        }
    }
}
