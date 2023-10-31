using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace rgparkins.cms.server
{
    public static class BsonClassMapper
    {
        static bool isInitialised;
        
        public static void Configure()
        {
            if (isInitialised) return;
            isInitialised = true;

            ConventionRegistry.Register("cms.conventaion",
                new ConventionPack
                {
                    new CamelCaseElementNameConvention(),
                    new NoIdMemberConvention(),
                    new IgnoreIfNullConvention(true),
                    new DelegateMemberMapConvention("DateTimeOffset", map =>
                    {
                        if (map.MemberType == typeof (DateTimeOffset))
                            map.SetSerializer(new DateTimeOffsetSerializer(BsonType.String));
                    }),
                    new DelegateMemberMapConvention("DateTimeOffset?", map =>
                    {
                        if (map.MemberType == typeof (DateTimeOffset?))
                            map.SetSerializer(new NullableSerializer<DateTimeOffset>(
                                new DateTimeOffsetSerializer(BsonType.String)));
                    }),
                    new NamedExtraElementsMemberConvention("UnmappedProperties"),
                    new EnumRepresentationConvention(BsonType.String)
                },
                _ => true);
        }
    }
}