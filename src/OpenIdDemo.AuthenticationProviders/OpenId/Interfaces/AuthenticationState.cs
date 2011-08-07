namespace OpenIdDemo.AuthenticationProviders.OpenId.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public enum AuthenticationState
    {
        Errored,
        Authenticating,
        Authenticated
    }
}
