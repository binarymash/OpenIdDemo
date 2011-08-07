namespace OpenIdDemo.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using OpenIdDemo.Domain.Interfaces;

    public interface IFactory
    {
        IGetRequest GetRequest(string identifier, string firstName, string lastName, string emailAddress);
        IGetResponse GetResponse(bool Ok, IUser user);
    }
}
