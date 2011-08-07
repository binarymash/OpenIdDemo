using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenIdDemo.Domain.Interfaces
{
    public interface IFactory
    {
        IUser User(string firstName, string lastName, string emailAddress);
    }
}
