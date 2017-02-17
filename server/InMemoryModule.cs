using Autofac;
using Parkwell.cms.server.product;

namespace Parkwell.cms.server
{
    public class InMemoryModule : Module 
    {
        protected override void Load(ContainerBuilder bldr) 
        {
            bldr.RegisterType<InMemoryProductStore>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}