using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User_Reg_BL_Library;
using RegistrationModelLibrary;
using System.Web.Http.Cors;

namespace FlightBookingWepApiProject.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,PUT,POST")]

    public class RegistrationController : ApiController
    {

        // GET: api/Registration
        RegBL bl = new RegBL();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Registration/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Registration
        public bool Post([FromBody]RegisterModel value)
        {
           
            if(bl.Insert_userBl(value.Firstname, value.Lastname, value.Dob.ToShortDateString(), value.Phonenumber, value.Email, value.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // DELETE: api/Registration/5
        public void Delete(int id)
        {
        }
    }
}
