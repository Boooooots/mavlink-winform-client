using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavLink;

namespace mavlinkWinformClient
{
    public class Subscriber
    {
        public Subscriber(string str)
        {
            this.name = str;
        }

        private string name;

        public void recvMsg(string st)
        {
            Console.WriteLine("recvMsg: " + st);
        }

        public void recvMavMsg(object sender, MavlinkPacket e)
        {
            
            Console.WriteLine("mavMsg: " + e.Message);
        }
        
    }
}
