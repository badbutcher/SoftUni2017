namespace HandMadeHttpServer.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using HandMadeHttpServer.Server.Handlers;
    using HandMadeHttpServer.Server.HTTP;
    using HandMadeHttpServer.Server.HTTP.Contracts;
    using HandMadeHttpServer.Server.Routing.Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            string request = await this.ReadRequest();

            if (string.IsNullOrEmpty(request) || string.IsNullOrWhiteSpace(request))
            {
                this.client.Shutdown(SocketShutdown.Both);
                return;
            }

            HttpContext httpContext = new HttpContext(request);

            IHttpResponse response = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

            if (response == null)
            {
                this.client.Shutdown(SocketShutdown.Both);
                return;
            }

            ArraySegment<byte> toBytes = new ArraySegment<byte>(Encoding.ASCII.GetBytes(response.Response));

            await this.client.SendAsync(toBytes, SocketFlags.None);

            Console.WriteLine(request);

            Console.WriteLine(response.Response);

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            string request = string.Empty;
            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            int numBytesRead;

            while ((numBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None)) > 0)
            {
                request += Encoding.ASCII.GetString(data.Array, 0, numBytesRead);
                if (numBytesRead < 1023)
                {
                    break;
                }
            }

            if (request.Length == 0)
            {
                return null;
            }

            return request;
        }
    }
}