using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User_Reg_BL_Library;
using SearchFlightModelLibrary;
using System.Web.Http.Cors;

namespace FlightBookingWepApiProject.Controllers
{
    public class SearchFlightController : ApiController
    {
        [EnableCors("http://localhost:4200", "*", "GET,PUT,POST")]
        // GET: api/SearchFlight
        public IEnumerable<string> Get()
        {
            RegBL bl = new RegBL();
            List<string> list = new List<string>();
            list = bl.FetchPlaceNames();
            return list;
        }

        // GET: api/SearchFlight/5
        public List<SearchFlight> Get(string date, string source, string destination)
        {
            RegBL bl = new RegBL();
            List<SearchFlight> list = new List<SearchFlight>();
            list = bl.getDetails(date, source, destination);
            return list;

        }
        // POST: api/SearchFlight
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SearchFlight/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SearchFlight/5
        public void Delete(int id)
        {
        }
    }
}
