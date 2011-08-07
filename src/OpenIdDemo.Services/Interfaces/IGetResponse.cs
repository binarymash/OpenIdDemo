namespace OpenIdDemo.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using OpenIdDemo.Domain.Interfaces;

    public interface IGetResponse
    {
        bool Ok { get; }
        IUser User { get; }
    }
}
