﻿namespace HandMadeHttpServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using HandMadeHttpServer.ByTheCakeApplication.Infrastructure;
    using HandMadeHttpServer.ByTheCakeApplication.Models;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public class CakesController : Controller
    {
        private static readonly List<Cake> Cakes = new List<Cake>();

        public IHttpResponse Add() => this.FileViewResponse(@"cakes\add", new Dictionary<string, string>
        {
            ["showResult"] = "none"
        });

        public IHttpResponse Add(string name, string price)
        {
            Cake cake = new Cake
            {
                Name = name,
                Price = decimal.Parse(price)
            };

            Cakes.Add(cake);

            using (StreamWriter streamWriter = new StreamWriter(@"ByTheCakeApplication\Data\database.csv", true))
            {
                streamWriter.WriteLine($"{name},{price}");
            }

            return this.FileViewResponse(@"cakes\add", new Dictionary<string, string>
            {
                ["name"] = name,
                ["price"] = price,
                ["showResult"] = "block"
            });
        }

        public IHttpResponse Search(IDictionary<string, string> urlParameters)
        {
            const string searchTermKey = "searchTerm";

            string results = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                string searchTerm = urlParameters[searchTermKey];

                var savedCakesDivs = File
                    .ReadAllLines(@"ByTheCakeApplication\Data\database.csv")
                    .Where(l => l.Contains(','))
                    .Select(l => l.Split(','))
                    .Select(l => new Cake
                    {
                        Name = l[0],
                        Price = decimal.Parse(l[1])
                    })
                    .Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()))
                    .Select(c => $"<div>{c.Name} - ${c.Price}</div>");

                results = string.Join(Environment.NewLine, savedCakesDivs);
            }

            return this.FileViewResponse(@"cakes\search", new Dictionary<string, string>
            {
                ["results"] = results
            });
        }
    }
}