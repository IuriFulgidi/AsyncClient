using SocketAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = null;
            string port= null;
            bool riprova = true;
            AsyncSocketClient mClient = new AsyncSocketClient();
            while (riprova)
            {
                Console.Write("Inserisci IP:");
                ip = Console.ReadLine();
                Console.Write("Inserisci Porta:");
                port = Console.ReadLine();
                
                if (mClient.SetServerIPAddress(ip) && mClient.SetServerPort(port))
                {
                    mClient.ConnectToServer();
                    riprova = false;
                }
            }

            while(true)
            {
                string msg = Console.ReadLine().ToLower();
                if (msg == "quit")
                    break;

                mClient.SendMessage(msg);
            }

        }
    }
}
