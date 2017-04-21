using Autofac;
using Parkwell.cms.server.metadata;
using Parkwell.cms.server.product;

namespace Parkwell.cms.server
{
    public class MongoStorageModule : Module {

        protected override void Load(ContainerBuilder builder) 
        {

        }
    }
    
    public class InMemoryStorageModule : Module 
    {
        protected override void Load(ContainerBuilder bldr) 
        {
            bldr.RegisterType<InMemoryProductStore>()
                .AsImplementedInterfaces()
                .SingleInstance();

            bldr.RegisterType<InMemoryMetadataStore>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}