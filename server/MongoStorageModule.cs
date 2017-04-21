using Autofac;
using MongoDB.Driver;
using Parkwell.cms.server.metadata;
using Parkwell.cms.server.product;

namespace Parkwell.cms.server
{
    public class MongoStorageModule : Module
    {
        string _connectionString;
        public MongoStorageModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder bldr)
        {
            var mongoUrl = MongoUrl.Create(_connectionString);

            var settings = MongoClientSettings.FromUrl(mongoUrl);
            settings.MaxConnectionPoolSize = 150;
            settings.MinConnectionPoolSize = 150;
            settings.WaitQueueSize = 500;

            bldr.Register(_ =>
                new MongoClient(settings)
                    .GetDatabase(mongoUrl.DatabaseName))
                   .As<IMongoDatabase>()
                   .SingleInstance();

            bldr.RegisterType<MongoProductStore>()
                     .AsImplementedInterfaces();

            bldr.RegisterType<MongoMetadataStore>()
                .AsImplementedInterfaces();
        }
    }
}