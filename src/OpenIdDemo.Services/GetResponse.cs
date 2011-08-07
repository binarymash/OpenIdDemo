namespace OpenIdDemo.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using OpenIdDemo.Domain.Interfaces;

    public class GetResponse : Interfaces.IGetResponse
    {
        public GetResponse(bool ok, IUser user)
        {
            Ok = ok;
            User = user;
        }

        public bool Ok{get; protected set;}
        public IUser User { get; protected set; }
    }
}
