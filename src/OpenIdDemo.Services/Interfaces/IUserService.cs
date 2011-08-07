namespace OpenIdDemo.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using OpenIdDemo.Domain;

    public interface IUserService
    {
        IFactory Factory { get; }
        IGetResponse Get(IGetRequest request);
    }
}
