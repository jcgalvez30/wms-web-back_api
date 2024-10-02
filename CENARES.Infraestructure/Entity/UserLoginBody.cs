using System;
using System.Collections;

namespace CENARES.Infraestructure.Entity
{
    public class UserLoginBody
    {
        private string _username;
        private string _password;
        private string _domainname;

        public UserLoginBody(string username, string password, string domainname) 
        { 
            this._username = username;
            this._password = password; 
            this._domainname = domainname;
        }

        public string Username { get => _username; }
        public string Password { get => _password; }
        public string DomainName { get => _domainname; }
    }
}
