using System;
using System.Collections.Generic;
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

            Socket sock;
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(IPAddress.Any ,1234));
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
            foreach (var element in conn.getAllBranchs())
            {

                Console.WriteLine("full name = " + element.Nom + " " );
                
            }
            Console.Read();*/
        }

    }
}
