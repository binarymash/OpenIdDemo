namespace OpenIdDemo.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IGetRequest
    {
        string Identifier { get; }
        string FirstName { get; }
        string LastName { get; }
        string EmailAddress { get; }
    }
}
