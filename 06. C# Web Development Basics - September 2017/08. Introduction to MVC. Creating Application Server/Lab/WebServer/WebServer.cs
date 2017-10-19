﻿namespace WebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using Contracts;

    public class WebServer : IRunnable
    {
        private const string LocalHostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly IHandleable mvcRequestHandler;

        private readonly TcpListener listener;

        private bool isRunning;

        public WebServer(int port, IHandleable mvcRequestHandler)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIpAddress), port);

            this.mvcRequestHandler = mvcRequestHandler;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server running on {LocalHostIpAddress}:{this.port}");

            Task.Run(this.ListenLoop).Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.mvcRequestHandler);
                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}