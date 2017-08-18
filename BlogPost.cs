using System;
using Nest;

namespace ElasticTutorial
{
    [ElasticsearchType(IdProperty = "Id", Name = "blog_post")]
    public class BlogPost
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return string.Format("Id: '{0}, Title: '{1}', Body: '{2}'", Id, Title, Body);
        }
    }
}
