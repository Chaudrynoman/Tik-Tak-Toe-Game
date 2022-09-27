using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;


namespace Servers
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient player1, player2;
            TcpListener myserver = new TcpListener(9267);
            myserver.Start();
            Console.WriteLine("Server Started");
            player1 = myserver.AcceptTcpClient();
            Console.WriteLine("Player one Want to play");
            player2 = myserver.AcceptTcpClient();
            Console.WriteLine("Player two Want to play");
            BinaryFormatter fobj = new BinaryFormatter();
            fobj.Serialize(player1.GetStream(), "1");
            fobj.Serialize(player2.GetStream(), "0");

            string msg;
            while (true)
            {
                msg = (string)fobj.Deserialize(player1.GetStream());
                fobj.Serialize(player2.GetStream(), msg);
                Console.WriteLine("Client Connected:");
                msg = (string)fobj.Deserialize(player2.GetStream());
                fobj.Serialize(player1.GetStream(), msg);


            }
        }
    }
}
