using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Contracts.Message
{
    public interface IMessageSender
    {
        public void SendingMessage(string message);
        public void SendingObject<T>(T obj);
    }
}
