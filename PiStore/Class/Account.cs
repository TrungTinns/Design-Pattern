using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStore.Class
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private Account(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public class AccountBuilder
        {
            private readonly string _username;
            private string _password;

            public AccountBuilder(string username)
            {
                _username = username;
            }

            public AccountBuilder WithPassword(string password)
            {
                _password = password;
                return this;
            }

            public Account Build()
            {
                return new Account(_username, _password);
            }
        }
    }
}
