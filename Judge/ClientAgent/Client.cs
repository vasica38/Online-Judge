using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace Judge.ClientAgent
{
    public class Client : IClient
    {
        private readonly TcpClient tcpClient;
        private readonly string address;
        private readonly int port;

        public Client(string address, int port)
        {
            this.address = address;
            this.port = port;
            this.tcpClient = new TcpClient();
        }

        public Stream Stream => this.tcpClient.GetStream();

        public void Dispose()
        {
            this.tcpClient.Close();
            throw new NotImplementedException();
        }

        public void Start()
        {
            try
            {
                this.tcpClient.Connect(address, port);
            }
            catch ( SocketException exception)
            {
                throw exception;
            }
        }

        public void Stop()
        {
            this.tcpClient.Close();
            //throw new NotImplementedException();
        }
    }
}