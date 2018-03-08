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
    public bool InsertReservation(int userID, int courseID, DateTime reservedTime, int numberHoles, int numberCarts, int numberPlayers)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

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
            parameter.ParameterName = "@NumberPlayers";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = numberPlayers;
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
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

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
            theReservation.NumberPlayers = int.Parse(dr["NumberPlayers"].ToString());

            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return theReservation;
    }

    public List<Reservation> SelectReservationBatchForMember(int userID)
    {
        List<Reservation> usersReservations = new List<Reservation>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

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
                r.NumberPlayers = int.Parse(dr["NumberPlayers"].ToString());
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
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

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
                r.NumberPlayers = int.Parse(dr["NumberPlayers"].ToString());
                theReservations.Add(r);
            }
            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return theReservations;
    }

    public bool UpdateReservation(int reservationID, int userID, int courseID, DateTime reservedTime, int numberHoles, int numberCarts, int numberPlayers)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

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
            parameter.ParameterName = "@NumberPlayers";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = numberPlayers;
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
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

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