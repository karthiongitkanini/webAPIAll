using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginModelLibrary
{
    public class UserLogin
    {
        string username, password;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
