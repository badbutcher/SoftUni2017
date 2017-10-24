namespace WebServer
{
    using System;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using global::WebServer.Contracts;
    using global::WebServer.Http.Response;
    using Http;
    using Http.Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IHandleable mvcRequestHandler;

        private readonly IHandleable resourceHandler;

        public ConnectionHandler(Socket client, IHandleable mvcRequestHandler, IHandleable resourceHandler)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(mvcRequestHandler, nameof(mvcRequestHandler));
            CoreValidator.ThrowIfNull(resourceHandler, nameof(resourceHandler));

            this.client = client;
            this.mvcRequestHandler = mvcRequestHandler;
            this.resourceHandler = resourceHandler;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                var httpResponse = await this.HandleRequest(httpRequest);

                var responseBytes = await this.GetResponseBytes(httpResponse);

                var byteSegments = new ArraySegment<byte>(responseBytes);

                await this.client.SendAsync(byteSegments, SocketFlags.None);

                Console.WriteLine($"-----REQUEST-----");
                Console.WriteLine(httpRequest);
                Console.WriteLine($"-----RESPONSE-----");
                Console.WriteLine(httpResponse);
                Console.WriteLine();
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<byte[]> GetResponseBytes(IHttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString()).ToList();

            if (response is FileResponse)
            {
                responseBytes.AddRange(((FileResponse)response).FileData);
            }

            return responseBytes.ToArray();
        }

        private async Task<IHttpResponse> HandleRequest(IHttpRequest request)
        {
            if (request.Path.Contains("."))
            {
                return this.resourceHandler.Handle(request);
            }
            else
            {
                string sessionIdToSend = this.SetRequestSession(request);

                var response = this.mvcRequestHandler.Handle(request);

                this.SetResponseSession(response, sessionIdToSend);

                return response;
            }
        }

        private void SetResponseSession(IHttpResponse response, string sessionIdToSend)
        {
            if (sessionIdToSend != null)
            {
                response.Headers.Add(
                    HttpHeader.SetCookie,
                    $"{SessionStore.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");
            }
        }

        private string SetRequestSession(IHttpRequest request)
        {
            if (!request.Cookies.ContainsKey(SessionStore.SessionCookieKey))
            {
                var sessionId = Guid.NewGuid().ToString();

                request.Session = SessionStore.Get(sessionId);

                return sessionId;
            }

            return null;
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();

            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = this.client.Receive(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }
    }
}