using MongoDB.Bson.Serialization;
using System.IO;
using MongoDB.Bson.IO;
using System;
using System.Text;

namespace Parkwell.cms.server.serialisation
{
    public class BsonConverter
    {
        public T Deserialise<T>(byte[] msg)
        {
            using (var memStream = new MemoryStream(msg))
            using (var strReader = new StreamReader(memStream))
            using (var jsonReader = new JsonReader(strReader))
            {
                return (T)BsonSerializer.Deserialize(jsonReader, typeof (T));
            }
        }

        public T Deserialise<T>(string msg)
        {
            using (var memStream = new MemoryStream(Encoding.ASCII.GetBytes(msg)))
            using (var strReader = new StreamReader(memStream))
            using (var jsonReader = new JsonReader(strReader))
            {
                return (T)BsonSerializer.Deserialize(jsonReader, typeof (T));
            }
        }

        public object Deserialise(byte[] msg, Type type)
        {
            using (var memStream = new MemoryStream(msg))
            using (var strReader = new StreamReader(memStream))
            using (var jsonReader = new JsonReader(strReader))
            {
                return BsonSerializer.Deserialize(jsonReader, type);
            }
        }

        public byte[] Serialise(object msg)
        {
            using (var memStream = new MemoryStream())
            using (var strReader = new StreamWriter(memStream))
            using (var writer = new JsonWriter(strReader, BsonSettings.DefaultWriterSettings))
            {
                BsonSerializer.Serialize(writer, msg.GetType(), msg);

                writer.Flush();
                memStream.Position = 0;

                return memStream.ToArray();
            }
        }
    }
}