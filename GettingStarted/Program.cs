using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {

            new Program().Run();
        }

        private void Run()
        {
            var zmqContext = ZeroMQ.ZmqContext.Create();
            startServer(zmqContext);
            startClient(zmqContext, "john");

            Task.Delay(500).Wait();

            startClient(zmqContext, "terry"); //and no...I'm not a Chelsea fan ;)

            Console.ReadLine();
        }

        private void startClient(ZmqContext zmqContext, string name)
        {
            Task.Factory.StartNew(() => doStartClient(zmqContext, name));
        }

        private void doStartClient(ZmqContext zmqContext, string name)
        {
            using (var client = zmqContext.CreateSocket(SocketType.REQ))
            {
                client.Connect("tcp://127.0.0.1:87");

                while (true)
                {
                    client.Send(name, Encoding.Unicode);
                    var response = client.Receive(Encoding.Unicode);

                    Task.Delay(2000).Wait();
                }
            }
        }

        private void startServer(ZmqContext context)
        {
            Task.Factory.StartNew(() => doStartServer(context));
        }

        private void doStartServer(ZmqContext context)
        {
            using (var server = context.CreateSocket(SocketType.REP))
            {
                server.Bind("tcp://127.0.0.1:87");

                while (true)
                {
                    var name = server.Receive(Encoding.Unicode);
                    server.Send(DateTime.Now.ToString() + " - " + name, Encoding.Unicode);

                    Console.WriteLine("Processed request from {0}", name);
                }
            }
        }
    }
}
