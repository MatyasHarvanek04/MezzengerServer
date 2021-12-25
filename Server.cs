using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

    namespace MezzengerServer
    {
    public static class Server {

        static TcpListener tcpServer;
        public static TcpListener TcpServer
        {
            get
            {

                return tcpServer;
            }
        }
           
        

        public static void init(string port, string ip)
        {
            if(!IPAddress.TryParse(ip, out IPAddress _ip))
            {
                Console.WriteLine("Invalid IP format!!");
                return;
            }
            if(!int.TryParse(port, out int _port))
            {
                Console.WriteLine("Invalid port format!!");
                return;
            }
            
            tcpServer = new TcpListener(_ip, _port);
            Console.WriteLine("Success! server is runing on: {0}:{1}", _ip.ToString(), _port);


            
            
        } 

        public static void closeServer()
        {
            tcpServer.Stop();
        }
    }
    }
