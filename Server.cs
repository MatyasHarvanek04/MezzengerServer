using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace MezzengerServer
    {
    public static class Server {

        static List<Thread> usersThreads = new List<Thread>();
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
            tcpServer.Start();
            Console.WriteLine("Success! server is runing on: {0}:{1}", _ip.ToString(), _port);
            addThread();

        } 

        public static void closeServer()
        {
            tcpServer.Stop();
        }

        static void ConnectionLoop()
        {
            TcpClient _listeningClient = tcpServer.AcceptTcpClient();
            Console.WriteLine("User connected");
            addThread();
            Console.WriteLine("Created new Thread!");

            byte[] buffer = new byte[1024];

            while(_listeningClient.Client.Receive(buffer, SocketFlags.Peek) != 0)
            {
                
                NetworkStream _netStream = _listeningClient.GetStream();

                buffer = new byte[1024];
                _netStream.Read(buffer, 0, buffer.Length);

                Console.WriteLine(Encoding.Default.GetString(buffer));
                Console.WriteLine("Number of connected users: {0}", usersThreads.Count);
                

                
            }

            usersThreads.Remove(Thread.CurrentThread);
        }


        static void addThread()
        {
            Thread T;
            T = new Thread(ConnectionLoop);
            usersThreads.Add(T);
            T.Start();
        }

        static void CheckConnections()
        {
            while (true)
            {
                for (int i = 0; i < usersThreads.Count; i++)
                {
                    if(usersThreads[i].ThreadState == ThreadState.Stopped)
                    {
                        if(usersThreads[i] != null)
                        {
                            usersThreads.RemoveAt(i);
                        }
                        
                    }

                }
            }


        }
    }
    }
