using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MezzengerServer
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Server.init("5000", "192.168.0.135");

        }
    }
}
