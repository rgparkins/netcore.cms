using MongoDB.Bson.IO;

namespace rgparkins.cms.server.serialisation
{
    public static class BsonSettings    
    {
        static BsonSettings()
        {
            DefaultWriterSettings = new JsonWriterSettings
            {
                OutputMode = JsonOutputMode.CanonicalExtendedJson
            };
        }
        public static JsonWriterSettings DefaultWriterSettings { get; set; }
    }
}