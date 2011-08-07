using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenIdDemo.Services
{
    public class GetRequest : Interfaces.IGetRequest
    {
        public GetRequest(string identifier, string firstName, string lastName, string emailAddress)
        {
            Identifier = identifier;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public string Identifier { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string EmailAddress { get; protected set; }
    }
}
