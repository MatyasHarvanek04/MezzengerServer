using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Newtonsoft.Json;

namespace MezzengerServer
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Server.init(Files.settings.Port, Files.settings.IP);
        }
    }
}
