
using System.Net.NetworkInformation;
using System.Text;

// Ping Google DNS Server 4.2.2.2

Ping pingSender = new Ping();
PingOptions pingOptions = new PingOptions();

pingOptions.DontFragment = true;

string data = "Learn to code in c#";
byte[] buffer = Encoding.ASCII.GetBytes(data);
int timeout = 120;
string adress = "4.2.2.2";

const int loopSize = 4;
for (int i = 0; i < loopSize; i++)
{

    PingReply pingReply = pingSender.Send(adress, timeout, buffer, pingOptions);

    if(pingReply.Status == IPStatus.Success)
    {
        Console.WriteLine("Ping to {0} - Response: {1}, RoundTrip: {2}, Time to live: {3}, Buffer size: {4};", adress, pingReply.Status.ToString(), pingReply.RoundtripTime, pingReply.Options.Ttl, pingReply.Buffer.Length);
    }
}


