using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDetailsModelLibrary
{
    public class FlightDetailsModel
    {
        string ft_id;
        string fd_id, source_id, destination_id, arrival, dateid, duration, fare;
        string departure;
        public string Ft_id { get => ft_id; set => ft_id = value; }
        public string Fd_id { get => fd_id; set => fd_id = value; }
        public string Source_id { get => source_id; set => source_id = value; }
        public string Destination_id { get => destination_id; set => destination_id = value; }
        public string Arrival { get => arrival; set => arrival = value; }
        public string Dateid { get => dateid; set => dateid = value; }
        public string Duration { get => duration; set => duration = value; }
        public string Fare { get => fare; set => fare = value; }
        public string Departure { get => departure; set => departure = value; }




    }
}
