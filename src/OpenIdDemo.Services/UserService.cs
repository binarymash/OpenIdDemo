namespace OpenIdDemo.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using OpenIdDemo.Domain.Interfaces;

    public class UserService : Interfaces.IUserService
    {
        public UserService(Interfaces.IFactory factory, IFactory domainFactory)
        {
            Factory = factory;
            _domainFactory = domainFactory;
        }

        public Interfaces.IFactory Factory { get; protected set; }

        public Interfaces.IGetResponse Get(Interfaces.IGetRequest request)
        {
            var user = _domainFactory.User(request.FirstName, request.LastName, request.EmailAddress);
            return Factory.GetResponse(true, user);
        }

        IFactory _domainFactory;
    }
}
