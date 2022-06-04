using System;
using System.Net;
using System.Net.Sockets;

namespace TesteConectividade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Connectivity Test...");
           
            Console.Write("Enter IP Address:");
            var host = Console.ReadLine();

            Console.Write("Enter port:");
            int port = Int32.Parse(Console.ReadLine());

            Console.Write("Enter with number Retries:");
            int retries = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < retries; i++)
            {
                if(retries > 1)
                    System.Threading.Thread.Sleep(3000);
                TestConnectivity(host, port);
            }
        }

        private static void TestConnectivity(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);

            port = port <= 0 ? 443 : port;
            try
            {
                s.Connect(IPs[0], port);
                Console.WriteLine($@"Host:{host} and Port:{port} Connectivity Done Success!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Host:{host} and Port:{port} Connectivity Wrong! \n Details: " + ex.Message);
                // something went wrong
            }
        }

    }



}
