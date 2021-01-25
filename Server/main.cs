using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class main
    {
        static void Main(string[] args)
        {
            Console.Title = "Serveur";

            int port = Int32.Parse(ConfigurationManager.AppSettings["communicationPort"]);
            Socket sock;
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(IPAddress.Any, 1234));
            sock.Listen(1);

            ConnectivityHandler connection = new ConnectivityHandler();

            while (true)
            {
                try
                {

                    Console.WriteLine("waiting for clients....");
                    Socket sockServeur = sock.Accept();
                    Console.WriteLine("Client " + sockServeur.RemoteEndPoint + " Connected.");
                    new ClientHandler(connection, sockServeur).Start();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }


            /*//just testing
            ConnectivityHandler conn = new ConnectivityHandler();

            conn.updateStudent(new Student(2, new Branch(1, "ghj"), "test", "test10", "test10", "test10", "test10", DateTime.Now, "test1"));
            Console.Read();*/
        }

    }
}
