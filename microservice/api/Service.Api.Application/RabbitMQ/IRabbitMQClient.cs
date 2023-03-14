using Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RabbitMQ
{
    public interface IRabbitMQClient
    {
        void SendRabbitMQClientQueues(QueuesRequest queuesRequest);
        Task<string> ReceiveRabbitMQClientQueues(QueuesRequest queuesRequest);
    }
}
