using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSDotNetWebAdvert.SearchWorker
{
    public static class ElasticSearchHelper
    {
        private static IElasticClient _client;

        public static IElasticClient GetInstance(IConfiguration config) {
            if (_client == null) {
                var url = config.GetSection("ES").GetValue<string>("url");
                var username = config.GetSection("ES").GetValue<string>("username");
                var password = config.GetSection("ES").GetValue<string>("password");

                var settings = new ConnectionSettings(new Uri(url))
                    .DefaultIndex("adverts")
                    .BasicAuthentication(username, password);

                _client = new ElasticClient(settings);
            }

            return _client;
        }
    }
}
