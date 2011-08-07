namespace OpenIdDemo.AuthenticationProviders.OpenId.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IAuthenticationRequest
    {
        string Url { get; }
    }
}
