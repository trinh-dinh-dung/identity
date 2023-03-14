using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Appsetting
{
    public class Appsettings
    {
        public string DefaultConnection { get; set; }
        public string Api_Authority { get; set; }
        public string Api_Gateway { get; set; }
        //Rabbitmq config
        public string Rabbitmq_UserName { get; set; }
        public string Rabbitmq_Password { get; set; }
        public string Rabbitmq_VirtualHost { get; set; }
        public string Rabbitmq_HostName { get; set; }
        public int Rabbitmq_Port { get; set; }
        //Rabbitmq queue name
        public string Rabbitmq_Queue_Sop { get; set; }

    }
}
