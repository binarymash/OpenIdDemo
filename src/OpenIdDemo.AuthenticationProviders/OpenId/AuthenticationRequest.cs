namespace OpenIdDemo.AuthenticationProviders.OpenId
{
    public class AuthenticationRequest : Interfaces.IAuthenticationRequest
    {
        public AuthenticationRequest(string url)
        {
            Url = url;
        }

        public string Url { get; protected set; }
    }
}
