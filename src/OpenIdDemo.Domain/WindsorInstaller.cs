namespace OpenIdDemo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Castle.Facilities.TypedFactory;

    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<Interfaces.IFactory>()
                    .AsFactory(),
                Component.For<Interfaces.IUser>()
                    .ImplementedBy<User>()
                    .LifeStyle.Transient
            );
        }
    }
}
