namespace OpenIdDemo.AuthenticationProviders.OpenId
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    using DotNetOpenAuth.OpenId.RelyingParty;

    public class AuthenticationResponse : Interfaces.IAuthenticationResponse
    {
        public AuthenticationResponse(Interfaces.OpenIdAuthenticationState state)
        {
            State = state;
        }

        public AuthenticationResponse(ActionResult authenticatingActionResult)
        {
            State = Interfaces.OpenIdAuthenticationState.Authenticating;
            AuthenticatingActionResult = authenticatingActionResult;
        }

        public ActionResult AuthenticatingActionResult { get; protected set; }
        public Interfaces.OpenIdAuthenticationState State { get; protected set; }
        public Interfaces.IUserIdentity UserIdentity { get; protected set; }
    }
}
