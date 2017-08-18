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

            var res = elastic.CreateIndex("my_first_index", descriptor => descriptor
                .Mappings(mappings => mappings
                    .Map<BlogPost>(mapper => mapper.AutoMap())));

            //var res = elastic.Map<BlogPost>(mapper => mapper.Index("my_first_index").AutoMap());

            Console.WriteLine(res.ApiCall.Success);
            Console.ReadLine();
        }
    }
}
