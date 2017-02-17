using MongoDB.Bson.IO;

namespace Parkwell.cms.server.serialisation
{
    public static class BsonSettings    
    {
        static BsonSettings()
        {
            DefaultWriterSettings = new JsonWriterSettings
            {
                OutputMode = JsonOutputMode.Strict
            };
        }
        public static JsonWriterSettings DefaultWriterSettings { get; set; }
    }
}