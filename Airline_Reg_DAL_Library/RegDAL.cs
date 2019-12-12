using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SearchFlightModelLibrary;
using PassengerModelLibrary;
using FlightDetailsModelLibrary;

namespace Airline_Reg_DAL_Library
{
    public class RegDAL
    {
        SqlConnection conn;
        SqlCommand  cmdFetchFlightDetails, cmdFetchCityName, cmdFetchPassword, cmdInsertUser, 
            cmdAddPassager, cmdInsertflight,cmdUpdatePass, cmdDeleteFlightDetails, cmdFetchDetails;
        public RegDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conFlight"].ConnectionString);
        }

        public string FetchPassword(string email)
        {
            cmdFetchPassword = new SqlCommand("Proc_UserLogin", conn);
            cmdFetchPassword.Parameters.Add("@email", SqlDbType.VarChar, 20);
            cmdFetchPassword.Parameters.Add("@password", SqlDbType.VarChar, 20);
            cmdFetchPassword.CommandType = CommandType.StoredProcedure;
            string password = null;

            conn.Open();

            cmdFetchPassword.Parameters[0].Value = email;
            cmdFetchPassword.Parameters[1].Direction = ParameterDirection.Output;
            cmdFetchPassword.ExecuteNonQuery();
            password = cmdFetchPassword.Parameters[1].Value.ToString();
            conn.Close();
            return password;

        }
        public bool CheckUser(string username)
        {
            bool val = false;
            cmdFetchPassword = new SqlCommand("Proc_UserLogin", conn);
            cmdFetchPassword.Parameters.Add("@email", SqlDbType.VarChar, 20);
            cmdFetchPassword.Parameters.Add("@password", SqlDbType.VarChar, 20);
            cmdFetchPassword.CommandType = CommandType.StoredProcedure;
            string password = null;

            conn.Open();

            cmdFetchPassword.Parameters[0].Value = username;
            cmdFetchPassword.Parameters[1].Direction = ParameterDirection.Output;
            cmdFetchPassword.ExecuteNonQuery();
            password = cmdFetchPassword.Parameters[1].Value.ToString();
            try
            {
                if (password != null && username!=null)
                {
                    val = true;
                }
            }
            catch (Exception)
            {

                val = false;
            }

             
            conn.Close();
            return val;
             

        }
        public List<SearchFlight> GetFlightDetails(string fldate, string source, string destination)
        {
            List<SearchFlight> details = new List<SearchFlight>();
            conn.Open();
            cmdFetchFlightDetails = new SqlCommand("proc_SearchFlight", conn);
            cmdFetchFlightDetails.Parameters.Add("@date", SqlDbType.VarChar, 10);
            cmdFetchFlightDetails.Parameters.Add("@source", SqlDbType.VarChar, 20);
            cmdFetchFlightDetails.Parameters.Add("@destination", SqlDbType.VarChar, 20);
            cmdFetchFlightDetails.CommandType = CommandType.StoredProcedure;
            cmdFetchFlightDetails.Parameters[0].Value = fldate;
            cmdFetchFlightDetails.Parameters[1].Value = source;
            cmdFetchFlightDetails.Parameters[2].Value = destination;
            SqlDataReader drFlightDetails = cmdFetchFlightDetails.ExecuteReader();
            SearchFlight search = null;
            //if (drFlightDetails.HasRows == false)
            //    throw new NoFlightInDatabaseException();
            while (drFlightDetails.Read())
            {
                search = new SearchFlight();
                search.Flightid = drFlightDetails[0].ToString();
                search.Departuretime = drFlightDetails[1].ToString();
                search.Arrivaltime = drFlightDetails[2].ToString();
                search.Duration = drFlightDetails[3].ToString();
                search.Fare = drFlightDetails[4].ToString();
                details.Add(search);
            }
            return details;

        }

        public List<string> FetchCityName()
        {
            List<string> cityName = new List<string>();
            cmdFetchCityName = new SqlCommand("proc_FetchCityName", conn);
            conn.Open();
            SqlDataReader drCityName = cmdFetchCityName.ExecuteReader();
            while (drCityName.Read())
            {
                cityName.Add(drCityName[0].ToString());
            }
            conn.Close();
            return cityName;
        }


        public bool Insert_user(string ufname, string ulname, string dob, string pnum, string gmail, string password)
        {
            bool return_value = false;
            
                
                cmdInsertUser = new SqlCommand("Insert_User_data", conn);
                cmdInsertUser.Parameters.Add("@ufname", SqlDbType.VarChar, 20);
                cmdInsertUser.Parameters.Add("@ulname", SqlDbType.VarChar, 20);
                cmdInsertUser.Parameters.Add("@dob", SqlDbType.Date);
                cmdInsertUser.Parameters.Add("@pnumber", SqlDbType.VarChar, 20);
                cmdInsertUser.Parameters.Add("@gmail", SqlDbType.VarChar, 20);
                cmdInsertUser.Parameters.Add("@password", SqlDbType.VarChar, 20);
                cmdInsertUser.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmdInsertUser.Parameters[0].Value = ufname;
                cmdInsertUser.Parameters[1].Value = ulname;
                cmdInsertUser.Parameters[2].Value = dob;
                cmdInsertUser.Parameters[3].Value = pnum;
                cmdInsertUser.Parameters[4].Value = gmail;
                cmdInsertUser.Parameters[5].Value = password;
                if (cmdInsertUser.ExecuteNonQuery() > 0)
                {
                    return_value = true;
                   
                }
             conn.Close();
            return return_value;
        }
        public bool Add_Passanger(PassengerModel p)
        {
            bool return_value = false;
            cmdAddPassager = new SqlCommand("Insert_Passenger", conn);

            cmdAddPassager.Parameters.Add("@Ps_Name", SqlDbType.VarChar, 20);
            cmdAddPassager.Parameters.Add("@Ps_Age", SqlDbType.VarChar, 2);
            cmdAddPassager.Parameters.Add("@Ps_gender", SqlDbType.VarChar, 20);
            cmdAddPassager.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmdAddPassager.Parameters[0].Value = p.Name;
            cmdAddPassager.Parameters[1].Value = p.Age;
            cmdAddPassager.Parameters[2].Value = p.Gender;
            if (cmdAddPassager.ExecuteNonQuery() > 0)
            {
                return_value = true;
            }
            conn.Close();
            return return_value;
        }
        public bool Insert_Flight(string FT_Id1, string startpt, string destination, string dprttym, string arrvltym, string date, string duration, string fare)
        {
            bool return_value = false;

            cmdInsertflight = new SqlCommand("proc_InsertFlight", conn);
            cmdInsertflight.Parameters.Add("@FT_Id", SqlDbType.VarChar, 6);
            cmdInsertflight.Parameters.Add("@startpt", SqlDbType.VarChar, 20);
            cmdInsertflight.Parameters.Add("@destination", SqlDbType.VarChar, 20);
            cmdInsertflight.Parameters.Add("@dprttym", SqlDbType.VarChar, 20);
            cmdInsertflight.Parameters.Add("@arrvltym", SqlDbType.VarChar, 20);
            cmdInsertflight.Parameters.Add("@date", SqlDbType.VarChar, 20);
            cmdInsertflight.Parameters.Add("@duration", SqlDbType.VarChar, 20);
            cmdInsertflight.Parameters.Add("@fare", SqlDbType.VarChar, 20);

            cmdInsertflight.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmdInsertflight.Parameters[0].Value = FT_Id1;
            cmdInsertflight.Parameters[1].Value = startpt;
            cmdInsertflight.Parameters[2].Value = destination;
            cmdInsertflight.Parameters[3].Value = dprttym;
            cmdInsertflight.Parameters[4].Value = arrvltym;
            cmdInsertflight.Parameters[5].Value = date;
            cmdInsertflight.Parameters[6].Value = duration;
            cmdInsertflight.Parameters[7].Value = fare;
            if (cmdInsertflight.ExecuteNonQuery() > 0)
            {
                return_value = true;
            }
            conn.Close();
            return return_value;
        }


        public bool update_detail(string id,FlightDetailsModel fl)
        {
            bool s = false;
            cmdUpdatePass = new SqlCommand("proc_updateflightdetails", conn);
            cmdUpdatePass.CommandType = CommandType.StoredProcedure;
            cmdUpdatePass.Parameters.AddWithValue("@fd_id", id);
            cmdUpdatePass.Parameters.AddWithValue("@dep_time", fl.Departure);
            cmdUpdatePass.Parameters.AddWithValue("@arr_time", fl.Arrival);
            cmdUpdatePass.Parameters.AddWithValue("@date_id", fl.Dateid);
            cmdUpdatePass.Parameters.AddWithValue("@duration", fl.Duration);
            cmdUpdatePass.Parameters.AddWithValue("@fare", fl.Fare);
            conn.Open();
            if ((cmdUpdatePass.ExecuteNonQuery() > 0))
                s = true;
            return s;
        }
        public bool Delete(string FD_Id)
        {
            bool return_value = false;

            cmdDeleteFlightDetails = new SqlCommand("proc_Delete", conn);
            cmdDeleteFlightDetails.Parameters.Add("@fd_id", SqlDbType.VarChar, 20);
            cmdDeleteFlightDetails.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmdDeleteFlightDetails.Parameters[0].Value = FD_Id;
            if (cmdDeleteFlightDetails.ExecuteNonQuery() > 0)
            {
                return_value = true;
            }
            conn.Close();
            return return_value;
        }
        public List<FlightDetailsModel> getAllDetails(int fid)
        {
            cmdFetchDetails = new SqlCommand("proc_flightDetails", conn);
            cmdFetchDetails.Parameters.Add("@fd_id", SqlDbType.Int);
            cmdFetchDetails.CommandType = CommandType.StoredProcedure;
            List<FlightDetailsModel> details = new List<FlightDetailsModel>();
            conn.Open();
            cmdFetchDetails.Parameters[0].Value = fid;
            SqlDataReader drUsers = cmdFetchDetails.ExecuteReader();
            FlightDetailsModel detail = null;
            while (drUsers.Read())
            {
                detail = new FlightDetailsModel();

                detail.Fd_id = drUsers[0].ToString();
                detail.Ft_id = drUsers[1].ToString();
                detail.Source_id = drUsers[2].ToString();
                detail.Destination_id = drUsers[3].ToString();
                detail.Departure = drUsers[4].ToString();
                detail.Arrival = drUsers[5].ToString();
                detail.Dateid = drUsers[6].ToString();
                detail.Duration = drUsers[7].ToString();
                detail.Fare = drUsers[8].ToString();
                details.Add(detail);
            }
            conn.Close();
            return details;

        }

    }

}
