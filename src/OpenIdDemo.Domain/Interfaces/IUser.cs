using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenIdDemo.Domain.Interfaces
{
    public interface IUser
    {
        string UserName { get; }
        string FirstName { get; }
        string LastName { get; }
        string FullName { get; }
        string EmailAddress { get; }
    }
}
