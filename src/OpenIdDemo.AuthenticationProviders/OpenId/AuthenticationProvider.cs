namespace OpenIdDemo.AuthenticationProviders.OpenId
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OpenId;
    using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
    using DotNetOpenAuth.OpenId.RelyingParty;

    using log4net;

    public class AuthenticationProvider : Interfaces.IAuthenticationProvider
    {

        public AuthenticationProvider(Interfaces.IFactory factory, OpenIdRelyingParty openIdRelyingParty)
        {
            Factory = factory;
            _openIdRelyingParty = openIdRelyingParty;
        }

        public Interfaces.IFactory Factory { get; protected set; }

        public Interfaces.IAuthenticationResponse Authenticate(Interfaces.IAuthenticationRequest request)
        {
            var response = _openIdRelyingParty.GetResponse();
            if (response == null)
            {
                return RequestAuthentication(request);
            }

            return GetUserIdentity(response);
        }

        #region Private 

        private readonly OpenIdRelyingParty _openIdRelyingParty;
        ILog _logger;

        private Interfaces.IAuthenticationResponse GetUserIdentity(IAuthenticationResponse response)
        {
            var identifier = response.ClaimedIdentifier;
            var fetch = response.GetExtension<FetchResponse>();
            Interfaces.IUserIdentity userIdentity = (fetch == null) 
                ? null 
                : Factory.GetUserIdentity(response.ClaimedIdentifier.ToString(),
                    fetch.GetAttributeValue(WellKnownAttributes.Name.First),
                    fetch.GetAttributeValue(WellKnownAttributes.Name.Last),
                    fetch.GetAttributeValue(WellKnownAttributes.Contact.Email));

            return Factory.AuthenticationResponse(userIdentity);
        }

        private Interfaces.IAuthenticationResponse RequestAuthentication(Interfaces.IAuthenticationRequest request)
        {
            Identifier id;
            if (!Identifier.TryParse(request.Url, out id))
            {
                _logger.Info(string.Format("OpenID Error...invalid url. url='{0}'", request.Url));
                return Factory.AuthenticationResponse(Interfaces.AuthenticationState.Errored);
            }

            try
            {
                var authenticationRequest = _openIdRelyingParty.CreateRequest(request.Url);
                var fetch = new FetchRequest();
                fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                fetch.Attributes.AddRequired(WellKnownAttributes.Name.First);
                fetch.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                authenticationRequest.AddExtension(fetch);

                var actionResult = authenticationRequest.RedirectingResponse.AsActionResult();
                return Factory.AuthenticationResponse(actionResult);
            }
            catch (ProtocolException ex)
            {
                _logger.Error("OpenID Exception...", ex);
                return Factory.AuthenticationResponse(Interfaces.AuthenticationState.Errored);
            }
        }
        
        #endregion

    }
}
