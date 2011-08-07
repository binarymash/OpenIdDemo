namespace OpenIdDemo.AuthenticationProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DotNetOpenAuth.OpenId.RelyingParty;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Castle.Facilities.TypedFactory;

    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<OpenId.Interfaces.IAuthenticationProvider>()
                    .ImplementedBy<OpenId.AuthenticationProvider>()
                    .LifeStyle.Transient,
                Component.For<OpenId.Interfaces.IAuthenticationRequest>()
                    .ImplementedBy<OpenId.AuthenticationRequest>()
                    .LifeStyle.Transient,
                Component.For<OpenId.Interfaces.IAuthenticationResponse>()
                    .ImplementedBy<OpenId.AuthenticationResponse>()
                    .LifeStyle.Transient,
                Component.For<OpenId.Interfaces.IUserIdentity>()
                    .ImplementedBy<OpenId.UserIdentity>()
                    .LifeStyle.Transient,
                Component.For<OpenId.Interfaces.IFactory>()
                    .AsFactory()
                    .LifeStyle.Transient,
                Component.For<OpenIdRelyingParty>()
                    .ImplementedBy<OpenIdRelyingParty>()
            );

        }
    }
}
