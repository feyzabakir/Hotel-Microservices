using RabbitMQ.Client;
using ReportAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Service.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly ConnectionFactory _factory;
        private readonly string _queueName;

        public RabbitMQService(string rabbitMQConnectionString, string queueName)
        {
            _factory = new ConnectionFactory { Uri = new Uri(rabbitMQConnectionString) };
            _queueName = queueName;
        }

        public async Task SendMessageAsync(string message)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: null,
                                     body: body);
            }

            await Task.CompletedTask;
        }
    }
}
