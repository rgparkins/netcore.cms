using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace Parkwell.cms.server
{
    public class CmsInputFormatter : IInputFormatter
    {
        public bool CanRead(InputFormatterContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var contentType = context.HttpContext.Request.ContentType;
            
            if (contentType == null || contentType.StartsWith("application/json"))
                return true;
            
            return false;
        }
        public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var request = context.HttpContext.Request;
            
            if (request.ContentLength == 0)
            {
                if (context.ModelType.GetTypeInfo().IsValueType)
                    return await InputFormatterResult.SuccessAsync(Activator.CreateInstance(context.ModelType));
                else 
                    return await InputFormatterResult.SuccessAsync(null);
            }
            
            var encoding = Encoding.UTF8;

            using (var reader = new StreamReader(context.HttpContext.Request.Body))
            {
                using (var bsonReader = new JsonReader(await reader.ReadToEndAsync()))
                {
                    var model = BsonSerializer.Deserialize(bsonReader, context.ModelType);
                    return await InputFormatterResult.SuccessAsync(model);
                }
            }
        }
    }
}