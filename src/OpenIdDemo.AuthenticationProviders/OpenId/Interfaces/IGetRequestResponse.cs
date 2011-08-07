namespace OpenIdDemo.AuthenticationProviders.OpenId.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    public interface IAuthenticationResponse
    {
        AuthenticationState State { get; }
        ActionResult AuthenticatingActionResult { get; }
        IUserIdentity UserIdentity { get; }
    }
}
