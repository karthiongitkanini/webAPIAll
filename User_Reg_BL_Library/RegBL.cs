using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFlightModelLibrary;
using Airline_Reg_DAL_Library;
using PassengerModelLibrary;
using FlightDetailsModelLibrary;



namespace User_Reg_BL_Library
{
    public class RegBL
    {
        RegDAL dal;
        public RegBL()
        {
            dal = new RegDAL();
        }
        public bool Login(string email, string password)
        {
            bool loginStatus = false;
            string databasePassword = dal.FetchPassword(email);
            if (databasePassword == password)
                loginStatus = true;
            return loginStatus;
        }


        public bool Insert_userBl(string ufname, string ulname, string dob,  string pnum,  string gmail, string password)
        {
            return dal.Insert_user(ufname, ulname, dob, pnum, gmail, password);
        }
        public List<SearchFlight> getDetails(string fldate, string source, string des)
        {
            return dal.GetFlightDetails(fldate, source, des);
        }
        public List<string> FetchPlaceNames()
        {
            return dal.FetchCityName();
        }
        public string checkUser(string umail)
        {
            string databasePassword = dal.FetchPassword(umail);
            return databasePassword;
            //return userdal.CheckUser(umail);
        }
        public bool Insert_Passenger(PassengerModel p)
        {
            return dal.Add_Passanger(p);
        }

        public bool Insert(string FT_Id, string startpt, string destination, string dprttym, string arrvltym, string date, string duration, string fare)
        {
            return dal.Insert_Flight(FT_Id, startpt, destination, dprttym, arrvltym, date, duration, fare);
        }
        public bool UpdateDetail(string id,FlightDetailsModel flight)
        {
            return dal.update_detail(id, flight);
        }
        public bool DeletingFlight(string FD_Id)
        {
            return dal.Delete(FD_Id);
        }
        public List<FlightDetailsModel> GetFlightDetails(int id)
        {
            return dal.getAllDetails(id);

        }

    }
}
