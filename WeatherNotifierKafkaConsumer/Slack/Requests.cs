using RestSharp;
using System.Text.Json;

namespace WeatherNotifierKafkaConsumer.Slack
{
    public class Requests
    {
        private AuthDetails authDetails;

        public Requests(AuthDetails authDetails)
        {
            this.authDetails = authDetails;
        }


        public void sendNotification(Notification notification)
        {
            RestClient client = new RestClient(authDetails.endpoint);
            RestRequest request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + authDetails.token);

            Dictionary<string, string> json = new Dictionary<string, string> { ["channel"] = authDetails.channelId, ["text"] = notification.text };
            string body = JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true });
            request.AddJsonBody(body);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
        }
    }
}
