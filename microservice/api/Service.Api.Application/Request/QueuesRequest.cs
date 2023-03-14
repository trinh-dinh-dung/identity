using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class QueuesRequest
    {
        public string QueueId { get; set; }
        public string QueueName { get; set; }
        public string QueueContent { get; set; }
        public int QueueStatus { get; set; }
        public string Rabbitmq_Queue_Name { get; set; }
    }
}
