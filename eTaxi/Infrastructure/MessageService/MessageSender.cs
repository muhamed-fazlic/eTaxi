using eTaxi.Application.Contracts.Message;
using eTaxi.Application.Models.RabbitMq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace eTaxi.Infrastructure.MessageService
{
    public class MessageSender :IMessageSender

    {
        private readonly string _host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq";
        private readonly string _username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
        private readonly string _password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
        private readonly string _virtualhost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST") ?? "/";

        private IConnection _connection;
        private IModel _channel;

        public MessageSender()
        {
            var factory = new ConnectionFactory
            {
                HostName = _host,
                UserName = _username,
                Password = _password,
                VirtualHost = _virtualhost,
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("etaxi_direct_exchange", ExchangeType.Direct);
        }
        public void SendingMessage(string message)
        {
            try
            {
                
                //var factory = new ConnectionFactory
                //{
                //    HostName = _host,
                //    UserName = _username,
                //    Password = _password,
                //    VirtualHost = _virtualhost,
                //};

                //using var connection = factory.CreateConnection();
                //using var channel = connection.CreateModel();

                //channel.ExchangeDeclare("etaxi_direct_exchange", ExchangeType.Direct);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                _channel.BasicPublish(exchange: "etaxi_direct_exchange", routingKey: "etaxi_key", basicProperties:null, body: body);


            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while sending message to RabbitMQ: {ex.Message}");
            }
        }

        public void SendingObject<T>(T obj)
        {
            Console.WriteLine("text");

            try
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));

                _channel.BasicPublish(exchange: "etaxi_direct_exchange", routingKey: "etaxi_key", basicProperties: null, body: body);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while sending object to RabbitMQ: {ex.Message}");
            }
        }

    }
}
