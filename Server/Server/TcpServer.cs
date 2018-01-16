using Server.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server.Server
{

    public class StateObject
    {
        public Socket socket;
        public const int BufferSize = 1024;
        public byte[] buffer;
        public StringBuilder sb;
        public StateObject()
        {
            this.socket = null;
            this.buffer = new byte[1024];
            this.sb = new StringBuilder(); ;
        }
    }

    public class TcpServer
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public static EventQueue Queue { set; get; }
        private static  SubmissionResult submission = new SubmissionResult();


        public TcpServer()
        {
            //this.submission = 
        }

        public static void Start()
        {
            byte[] bytes = new Byte[1024];
            //{192.168.43.4}
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            int idx = 0;
            for(int i = 0; i < ipHostInfo.AddressList.Length; ++i)
            {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    idx = i;
                    break;
                }
            }

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    allDone.Reset();

                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }


        public static void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            Console.WriteLine("new connection");

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject
            {
                socket = handler
            };
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            Console.WriteLine("read data");

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.socket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                content = state.sb.ToString();

                SubmissionEvent submissionEvent = new SubmissionEvent(Queue);
                submissionEvent.Subscribe(content);
                submissionEvent.Notify();

                Console.WriteLine("read data {0} ", content);
            }
        }


        private static void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Send(handler, submission.Score.ToString());
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }

 
}
