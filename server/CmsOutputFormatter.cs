using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using Parkwell.cms.server.serialisation;

namespace Parkwell.cms.server
{
    public class CmsOutputFormatter : IOutputFormatter
    {
        public bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return true;
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.ContentType == null  || context.ContentType.ToString().StartsWith("application/json"))
                return true;

            return false;
        }

        public Task WriteAsync(OutputFormatterWriteContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            
            using (var writer = new StreamWriter(response.Body)) 
                using (var bsonWriter = new JsonWriter(writer, BsonSettings.DefaultWriterSettings))
                    BsonSerializer.Serialize(bsonWriter, context.ObjectType, context.Object);

            return Task.FromResult(0);
        }
    }
}