using Elasticsearch.Net;
using Nest;
using System;

namespace ElasticSearchClient
{
    public class ElasticSearchFactory
    {
        public ElasticClient ElasticSearchClient()
        {
            var nodes = new Uri[]
            {
                //new Uri("http://localhost:9200/"),
                new Uri("http://elastic:NlPYZIUsFzkRivtq-wWC@localhost:9200/"),
            };

            var connectionPool = new StaticConnectionPool(nodes);
            var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming();
            var elasticClient = new ElasticClient(connectionSettings.DefaultIndex("catalogs"));

            return elasticClient;

            //var nodes = new Uri[]
            //{
            //    //new Uri("http://localhost:9200/"),
            //    new Uri("http://elastic:NlPYZIUsFzkRivtq-wWC@localhost:9200/"),
            //};

            //var connectionPool = new StaticConnectionPool(nodes);
            //var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming();
            //var elasticClient = new ElasticClient(connectionSettings.DefaultIndex("productdetails"));
            //return elasticClient;
        }
    }
}
