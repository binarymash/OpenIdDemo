namespace OpenIdDemo.AuthenticationProviders.OpenId.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IUserIdentity
    {
        string Identifier { get; }        
        string FirstName { get; }
        string LastName { get; }
        string EmailAddress { get; }
    }
}
