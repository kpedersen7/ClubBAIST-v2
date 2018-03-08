using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StandingReservationController
/// </summary>
public class StandingReservationController
{
    public bool InsertStandingReservation(int userID, int courseID, DateTime reservedTime, DateTime endTime, int numberHoles, int numberCarts, string player2, string player3, string player4)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "InsertStandingReservation";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = userID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@CourseID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = courseID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@ReservedTime";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Value = reservedTime;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@EndTime";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Value = endTime;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@NumberHoles";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = numberHoles;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@NumberCarts";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = numberCarts;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Player2";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = player2;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Player3";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = player3;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Player4";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = player4;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            ClubBAISTConnection.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public StandingReservation SelectStandingReservation(int standingReservationID)
    {
        StandingReservation theStandingReservation = new StandingReservation();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectStandingReservation";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@StandingReservationID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = standingReservationID;
            parameter.Direction = ParameterDirection.Input;

            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            dr.Read();

            theStandingReservation.StandingReservationID = int.Parse(dr["StandingReservationID"].ToString());
            theStandingReservation.UserID = int.Parse(dr["UserID"].ToString());
            theStandingReservation.CourseID = int.Parse(dr["CourseID"].ToString());
            theStandingReservation.ReservedTime = DateTime.Parse(dr["ReservedTime"].ToString());
            theStandingReservation.EndTime = DateTime.Parse(dr["EndTime"].ToString());
            theStandingReservation.NumberHoles = int.Parse(dr["NumberHoles"].ToString());
            theStandingReservation.NumberCarts = int.Parse(dr["NumberCarts"].ToString());
            theStandingReservation.Player2 = dr["Player2"].ToString();
            theStandingReservation.Player3 = dr["Player3"].ToString();
            theStandingReservation.Player4 = dr["Player4"].ToString();
            theStandingReservation.Approved = int.Parse(dr["Approved"].ToString());
            theStandingReservation.Active = int.Parse(dr["Active"].ToString());

            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return theStandingReservation;
    }

    public List<StandingReservation> SelectStandingReservations(int approved, int active)
    {
        List<StandingReservation> theStandingReservations = new List<StandingReservation>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectStandingReservations";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Approved";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = approved;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Active";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = active;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            while (dr.Read())
            {
                StandingReservation r = new StandingReservation();
                r.StandingReservationID = int.Parse(dr["StandingReservationID"].ToString());
                r.UserID = int.Parse(dr["UserID"].ToString());
                r.CourseID = int.Parse(dr["CourseID"].ToString());
                r.ReservedTime = DateTime.Parse(dr["ReservedTime"].ToString());
                r.EndTime = DateTime.Parse(dr["EndTime"].ToString());
                r.NumberHoles = int.Parse(dr["NumberHoles"].ToString());
                r.NumberCarts = int.Parse(dr["NumberCarts"].ToString());
                r.Player2 = dr["Player2"].ToString();
                r.Player3 = dr["Player3"].ToString();
                r.Player4 = dr["Player4"].ToString();
                r.Approved = int.Parse(dr["Approved"].ToString());
                r.Active = int.Parse(dr["Active"].ToString());
                theStandingReservations.Add(r);
            }
            ClubBAISTConnection.Close();
        }
        catch(Exception e)
        {

        }
        return theStandingReservations;
    }

    public bool UpdateStandingReservation(int standingReservationID, int userID, int courseID, DateTime reservedTime, DateTime endTime, int numberHoles, int numberCarts, string player2, string player3, string player4)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "UpdateStandingReservation";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@StandingReservationID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = standingReservationID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@UserID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = userID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@CourseID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = courseID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@ReservedTime";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Value = reservedTime;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@EndTime";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Value = endTime;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@NumberHoles";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = numberHoles;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@NumberCarts";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = numberCarts;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Player2";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = player2;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Player3";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = player3;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Player4";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = player4;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            ClubBAISTConnection.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateStandingReservationApproval(int standingReservationID, int approved, int active)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "UpdateStandingReservationApproval";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@StandingReservationID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = standingReservationID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Approved";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = approved;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Active";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = active;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            ClubBAISTConnection.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
}