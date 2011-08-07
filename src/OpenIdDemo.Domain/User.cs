namespace OpenIdDemo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class User : Interfaces.IUser
    {
        public User(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public string UserName
        {
            get { return EmailAddress; }
        }

        public string FullName
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0} {1}", FirstName, LastName); }
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string EmailAddress { get; protected set; }
    }
}
