using Application.Common.Appsetting;
using Application.Request;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RabbitMQ
{
    public class RabbitMQClient : IRabbitMQClient
    {
        private IOptions<Appsettings> _appsettings;

        public RabbitMQClient(IOptions<Appsettings> appsettings)
        {
            this._appsettings = appsettings;
        }

        public void SendRabbitMQClientQueues(QueuesRequest queuesRequest)
        {
            var factory = new ConnectionFactory()
            {
                UserName = _appsettings.Value.Rabbitmq_UserName,
                Password = _appsettings.Value.Rabbitmq_Password,
                VirtualHost = _appsettings.Value.Rabbitmq_VirtualHost,
                HostName = _appsettings.Value.Rabbitmq_HostName,
                Port = _appsettings.Value.Rabbitmq_Port,
            };

            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queuesRequest.Rabbitmq_Queue_Name,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(queuesRequest);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                     routingKey: queuesRequest.Rabbitmq_Queue_Name,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
            //connection.Close();
        }

        public async Task<string> ReceiveRabbitMQClientQueues(QueuesRequest queuesRequest)
        {
            var messAll = "";
            var factory = new ConnectionFactory()
            {
                UserName = _appsettings.Value.Rabbitmq_UserName,
                Password = _appsettings.Value.Rabbitmq_Password,
                VirtualHost = _appsettings.Value.Rabbitmq_VirtualHost,
                HostName = _appsettings.Value.Rabbitmq_HostName,
                Port = _appsettings.Value.Rabbitmq_Port,
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queuesRequest.Rabbitmq_Queue_Name,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    if (!string.IsNullOrEmpty(message))
                    {
                        messAll = messAll + message;
                        await Task.Yield();
                    }
                };
                channel.BasicConsume(queue: queuesRequest.Rabbitmq_Queue_Name,
                                     autoAck: true,
                                     consumer: consumer);
                return messAll;
            }
        }

    }
}
