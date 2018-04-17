using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReservationController
/// </summary>
public class ReservationController
{
    public bool InsertReservation(int userID, int courseID, DateTime reservedTime, int numberHoles, int numberCarts, string player2, string player3, string player4, int isStandingReservation)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "InsertReservation";

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

            parameter = new SqlParameter();
            parameter.ParameterName = "@IsStandingReservation";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = isStandingReservation;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            ClubBAISTConnection.Close();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public Reservation SelectReservation(int reservationID)
    {
        Reservation theReservation = new Reservation();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectReservation";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ReservationID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = reservationID;
            parameter.Direction = ParameterDirection.Input;

            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            dr.Read();

            theReservation.ReservationID = int.Parse(dr["ReservationID"].ToString());
            theReservation.UserID = int.Parse(dr["UserID"].ToString());
            theReservation.CourseID = int.Parse(dr["CourseID"].ToString());
            theReservation.ReservedTime = DateTime.Parse(dr["ReservedTime"].ToString());
            theReservation.NumberHoles = int.Parse(dr["NumberHoles"].ToString());
            theReservation.NumberCarts = int.Parse(dr["NumberCarts"].ToString());
            theReservation.Player2 = dr["Player2"].ToString();
            theReservation.Player3 = dr["Player3"].ToString();
            theReservation.Player4 = dr["Player4"].ToString();

            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return theReservation;
    }

    public List<Reservation> SelectReservationBatchForMember(int userID, string email)
    {
        List<Reservation> usersReservations = new List<Reservation>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectReservationBatchForMember";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = userID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@UserEmail";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = email;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            while (dr.Read())
            {
                Reservation r = new Reservation();
                r.ReservationID = int.Parse(dr["ReservationID"].ToString());
                r.UserID = int.Parse(dr["UserID"].ToString());
                r.CourseID = int.Parse(dr["CourseID"].ToString());
                r.ReservedTime = DateTime.Parse(dr["ReservedTime"].ToString());
                r.NumberHoles = int.Parse(dr["NumberHoles"].ToString());
                r.NumberCarts = int.Parse(dr["NumberCarts"].ToString());
                r.Player2 = dr["Player2"].ToString();
                r.Player3 = dr["Player3"].ToString();
                r.Player4 = dr["Player4"].ToString();
                usersReservations.Add(r);
            }
            ClubBAISTConnection.Close();
        }
        catch
        {

        }

        return usersReservations;
    }

    public List<Reservation> SelectReservationBatchByTimeFrame(DateTime minDay, DateTime maxDay)
    {
        List<Reservation> theReservations = new List<Reservation>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectReservationBatchByTimeFrame";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MinDay";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Value = minDay;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@MaxDay";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Value = maxDay;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            while (dr.Read())
            {
                Reservation r = new Reservation();
                r.ReservationID = int.Parse(dr["ReservationID"].ToString());
                r.UserID = int.Parse(dr["UserID"].ToString());
                r.CourseID = int.Parse(dr["CourseID"].ToString());
                r.ReservedTime = DateTime.Parse(dr["ReservedTime"].ToString());
                r.NumberHoles = int.Parse(dr["NumberHoles"].ToString());
                r.NumberCarts = int.Parse(dr["NumberCarts"].ToString());
                r.Player2 = dr["Player2"].ToString();
                r.Player3 = dr["Player3"].ToString();
                r.Player4 = dr["Player4"].ToString();
                theReservations.Add(r);
            }
            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return theReservations;
    }

    public bool UpdateReservation(int reservationID, int userID, int courseID, DateTime reservedTime, int numberHoles, int numberCarts, string player2, string player3, string player4)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "UpdateReservation";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ReservationID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = reservationID;
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

    public bool DeleteReservation(int reservationID)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "DeleteReservation";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ReservationID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = reservationID;
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