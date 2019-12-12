using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerModelLibrary
{
    public class PassengerModel
    {
        string name, gender;
        int age;

        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
    }
}
