using eTaxi.NotificationService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace eTaxi.NotificationService
{
    public class RabbitMQConsumer : BackgroundService
    {

        private IConnection _connection;
        private IModel _channel;
        private readonly ILogger<RabbitMQConsumer> _logger;
        private IEmailSender _emailSender;

        private readonly string _host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq";
        private readonly string _username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
        private readonly string _password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
        private readonly string _virtualhost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST") ?? "/";

        public RabbitMQConsumer(ILogger<RabbitMQConsumer> logger, IEmailSender emailSender)
        {
            var factory = new ConnectionFactory
            {
                HostName = _host,
                UserName = _username,
                Password = _password
            };

            _logger = logger;
            _emailSender = emailSender;

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("etaxi_direct_exchange", ExchangeType.Direct);

            _channel.QueueDeclare(queue: "etaxi_notification",
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
            _channel.QueueBind("etaxi_notification", "etaxi_direct_exchange", routingKey: "etaxi_key");

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();



            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                _logger.LogInformation(" [x] Received {0}", message);

                var emailMessage = new EmailMessage(new string[] { "info.etaxi2@gmail.com" }, "Nova narudzba", "Napravljena je nova narudzba");
                _emailSender.SendEmailAsync(emailMessage);
            };
            _channel.BasicConsume(queue: "etaxi_notification",
                                 autoAck: true,
                                 consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                // handle more tasks if you want to...
                await Task.Delay(5000, stoppingToken);
            }
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }


    }
}
