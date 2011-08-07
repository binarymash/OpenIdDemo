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
        public AuthenticationResponse(Interfaces.AuthenticationState state)
        {
            State = state;
        }

        public AuthenticationResponse(ActionResult authenticatingActionResult)
        {
            State = Interfaces.AuthenticationState.Authenticating;
            AuthenticatingActionResult = authenticatingActionResult;
        }

        public AuthenticationResponse(Interfaces.IUserIdentity userIdentity)
        {
            State = Interfaces.AuthenticationState.Authenticated;
            UserIdentity = userIdentity;
        }

        public ActionResult AuthenticatingActionResult { get; protected set; }
        public Interfaces.AuthenticationState State { get; protected set; }
        public Interfaces.IUserIdentity UserIdentity { get; protected set; }
    }
}
