using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationModelLibrary
{
    public class RegisterModel
    {
        string firstname, lastname, nationality, gender, phonenumber, email, password;
        DateTime dob;

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Dob { get => dob; set => dob = value; }
    }
}
