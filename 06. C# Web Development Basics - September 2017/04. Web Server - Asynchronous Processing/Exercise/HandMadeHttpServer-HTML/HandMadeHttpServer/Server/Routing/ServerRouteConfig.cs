﻿namespace HandMadeHttpServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using HandMadeHttpServer.Server.Enums;
    using HandMadeHttpServer.Server.Handlers;
    using HandMadeHttpServer.Server.Routing.Contracts;

    public class ServerRouteConfig : IServerRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>>();

            var availableMethods = Enum
                .GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, IRoutingContext>();
            }

            this.InitializeServerConfig(appRouteConfig);
        }

        public Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes => this.routes;

        private void InitializeServerConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (KeyValuePair<HttpRequestMethod, Dictionary<string, RequestHandler>> kvp in appRouteConfig.Routes)
            {
                foreach (KeyValuePair<string, RequestHandler> requestHandler in kvp.Value)
                {
                    List<string> args = new List<string>();

                    string parsedRegex = this.ParseRoute(requestHandler.Key, args);

                    IRoutingContext routingContext = new RoutingContext(requestHandler.Value, args);

                    this.routes[kvp.Key].Add(parsedRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string requestHandlerKey, List<string> args)
        {
            StringBuilder parsedRegex = new StringBuilder();
            parsedRegex.Append('^');

            if (requestHandlerKey == "/")
            {
                parsedRegex.Append($"{requestHandlerKey}$");
                return parsedRegex.ToString();
            }

            string[] tokens = requestHandlerKey.Split('/');

            this.ParseTokens(args, tokens, parsedRegex);

            return parsedRegex.ToString();
        }

        private void ParseTokens(List<string> args, string[] tokens, StringBuilder parsedRegex)
        {
            for (int idx = 0; idx < tokens.Length; idx++)
            {
                string end = idx == tokens.Length - 1 ? "$" : "/";
                if (!tokens[idx].StartsWith("{") && !tokens[idx].EndsWith("}"))
                {
                    parsedRegex.Append($"{tokens[idx]}{end}");
                    continue;
                }

                string pattern = "<\\w+>";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(tokens[idx]);

                if (!match.Success)
                {
                    continue;
                }

                string paramName = match.Groups[0].Value.Substring(1, match.Groups[0].Length - 2);
                args.Add(paramName);
                parsedRegex.Append($"{tokens[idx].Substring(1, tokens[idx].Length - 2)}{end}");
            }
        }
    }
}