using Nest;
using System;

namespace ElasticTutorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            var local = new Uri("http://localhost.docker:9200");
            var settings = new ConnectionSettings(local);
            var elastic = new ElasticClient(settings);

            var res = elastic.ClusterHealth();

            Console.WriteLine(res.ClusterName);
            Console.ReadLine();
        }
    }
}
