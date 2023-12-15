using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Pinger
{
    public class PingService
    {
        public string Data { get; set; }
        public byte[] Buffer { get; set; }
        public int Timeout { get; set; }
        public string Address { get; set; }
        public Ping pingerSender{ get; set; }
        public PingOptions pingOptions { get; set; }

        public PingService(string address, string data)
        {
            Data = data;
            Timeout = 120;
            Address = address;
            Buffer = Encoding.ASCII.GetBytes(data.ToString());
            pingerSender = new Ping();
            pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
        }

        public bool SendPing(int count)
        {
            List<bool> results = new List<bool>();
            for (int i = 0; i < count; i++)
            {
                PingReply reply = pingerSender.Send(Address, Timeout, Buffer, pingOptions);
                bool result = reply.Status == IPStatus.Success;
                results.Add(result);
                if(result == false) return false;
            }
            return true;
        }
        
    }
}
