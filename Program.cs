using Nest;
using System;
using Elasticsearch.Net;

namespace ElasticTutorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            var local = new Uri("http://localhost.docker:9200");
            var settings = new ConnectionSettings(local);
            var elastic = new ElasticClient(settings);

            /******************************************************************************************
             * Creating Index                                                                         *
             * ****************************************************************************************
             *  var res = elastic.CreateIndex("my_first_index", descriptor => descriptor              *
             *      .Mappings(mappings => mappings                                                    *
             *          .Map<BlogPost>(mapper => mapper.AutoMap())));                                 *
             *                                                                                        *
             *  var res = elastic.Map<BlogPost>(mapper => mapper.Index("my_first_index").AutoMap());  *
             *****************************************************************************************/

            var blogPost = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "First blog post",
                Body = "This is a very long blog post!"
            };

            var firstId = blogPost.Id;

            var res = elastic.Index(blogPost, p => p
                .Index("my_first_index")
                .Id(blogPost.Id.ToString())
                .Refresh(Refresh.True));

            


            Console.WriteLine(res.ApiCall.Success);
            Console.ReadLine();
        }
    }
}
