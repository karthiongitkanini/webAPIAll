using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightDetailsModelLibrary;
using User_Reg_BL_Library;
using System.Web.Http.Cors;


namespace FlightBookingWepApiProject.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,PUT,POST")]
    public class AdminController : ApiController
    {
        static List<FlightDetailsModel> details = new List<FlightDetailsModel>();
        RegBL bl;
        // GET: api/Admin
        public AdminController()
        {
            bl = new RegBL();

        }
        public IEnumerable<FlightDetailsModel> Get(int uid)
        {
            details = bl.GetFlightDetails(uid);
            return details;
        }

        // GET: api/Admin/5
        //public IEnumerable<FlightDetailsModel> Get()
        //{
        //    // return "value";

            
        //}

        // POST: api/Admin
        public void Post([FromBody]FlightDetailsModel value)
        {
            string s = "";
            string s2 = "D0";

            int n = value.Dateid.Length;
            s = value.Dateid.Substring(8, 2);
            s = s2 + s;
            bl.Insert(value.Ft_id, value.Source_id, value.Destination_id, value.Departure, value.Arrival, s, value.Duration, value.Fare);

        }

        // PUT: api/Admin/5
        public bool Put(string id, [FromBody]FlightDetailsModel flight)
        {
            bool s = false;
            var user = (from u in details
                        where u.Fd_id == id
                        select u).First();

            if (bl.UpdateDetail(id, flight))
                s = true;
            else
                s = false;
            return s;



        }

        // DELETE: api/Admin/5
        public void Delete(string  flightid)
        {
            bl.DeletingFlight(flightid);
        }
    }
}
