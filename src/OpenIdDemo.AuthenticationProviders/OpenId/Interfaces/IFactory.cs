using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace OpenIdDemo.AuthenticationProviders.OpenId.Interfaces
{
    public interface IFactory
    {
        IUserIdentity GetUserIdentity(string identifier, string firstName, string lastName, string emailAddress);
        IAuthenticationRequest AuthenticationRequest(string url);
        IAuthenticationResponse AuthenticationResponse(AuthenticationState state);
        IAuthenticationResponse AuthenticationResponse(ActionResult authenticatingActionResult);
        IAuthenticationResponse AuthenticationResponse(IUserIdentity userIdentity);
    }
}
