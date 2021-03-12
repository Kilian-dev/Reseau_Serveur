using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Reseau_Serveur
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket Le_Socket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint Adresse_process_locale = new IPEndPoint(IPAddress.Any, 999);

            Le_Socket.Bind(Adresse_process_locale); // attacher un processuce a un port 

            byte[] Data = new byte[1000];

            Console.WriteLine("en attente de reception..");
            EndPoint Adresse_process_Distant = new IPEndPoint(IPAddress.Any, 0);
            int Nombre_Octet = Le_Socket.ReceiveFrom(Data, ref Adresse_process_Distant);

            Console.WriteLine($"reception de {Nombre_Octet} octets");
            for(int i =0;i < Nombre_Octet; i++)
            {
                Console.Write(Convert.ToChar(Data[i]));
            }
            Console.WriteLine();
        }
    }
}
