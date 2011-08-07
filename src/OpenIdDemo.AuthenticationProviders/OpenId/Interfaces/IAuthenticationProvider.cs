namespace OpenIdDemo.AuthenticationProviders.OpenId.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OpenId;
    using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
    using DotNetOpenAuth.OpenId.RelyingParty;

    public interface IAuthenticationProvider
    {
        IAuthenticationResponse Authenticate(IAuthenticationRequest request);
        IFactory Factory { get; }
    }
}
