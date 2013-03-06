using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = ZmqContext.Create();

            using (var client = context.CreateSocket(SocketType.REQ))
            {
                client.Connect("tcp://127.0.0.1:87");

                while (true)
                {
                    client.Send("wilma", Encoding.Unicode);
                    var res = client.Receive(Encoding.Unicode);

                    Console.WriteLine(res);

                    Console.WriteLine("foo");

                    Task.Delay(1500).Wait();
                }
            }
        }
    }
}
