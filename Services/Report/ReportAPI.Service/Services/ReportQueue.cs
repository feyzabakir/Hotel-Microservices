using MongoDB.Driver.Core.Connections;
using RabbitMQ.Client;
using ReportAPI.Infrastructure;
using ReportAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Service.Services
{
    public class ReportQueue : IReportQueue
    {
        private readonly string _queueName;
        private readonly ConnectionFactory _factory;

        public ReportQueue(string queueName, string rabbitMQConnectionString)
        {
            _queueName = queueName;
            _factory = new ConnectionFactory { Uri = new System.Uri(rabbitMQConnectionString) };
        }

        public async Task EnqueueReportAsync(ReportRequest request)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = $"Location: {request.Location}, ReportId: {request.ReportId}";
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
