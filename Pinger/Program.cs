using Pinger;

PingService myPing = new PingService("4.2.2.2", "Learn to code in c#");

Console.WriteLine(myPing.SendPing(4));

