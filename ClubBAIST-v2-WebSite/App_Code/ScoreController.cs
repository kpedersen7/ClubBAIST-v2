using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ScoreController
/// </summary>
public class ScoreController
{
    public bool InsertScore(int reservationID,string email, int[] scores, int total, decimal handicapDifferential)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "InsertScore";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ReservationID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = reservationID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@UserEmail";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = email;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            int j = 1;
            foreach (int i in scores)
            {
                parameter = new SqlParameter();
                parameter.ParameterName = "@Score" + j;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = scores[j-1];
                parameter.Direction = ParameterDirection.Input;
                ClubBAISTCommand.Parameters.Add(parameter);
                j++;
            }

            parameter = new SqlParameter();
            parameter.ParameterName = "@RoundTotal";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = total;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@HandicapDifferential";
            parameter.SqlDbType = SqlDbType.Decimal;
            parameter.Value = handicapDifferential;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            ClubBAISTConnection.Close();
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }

    public List<Score> SelectScores(string email)
    {
        List<Score> theScores = new List<Score>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectScores";

            SqlParameter parameter = new SqlParameter();
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
                Score s = new Score();
                s.ReservationID = int.Parse(dr["ReservationID"].ToString());
                s.UserEmail = dr["UserEmail"].ToString();
                s.Scores = new int[18];
                for (int i = 1; i < 18; i++)
                {
                    s.Scores[i - 1] = int.Parse(dr["ScoreHole" + i.ToString()].ToString());
                }
                s.RoundTotal = int.Parse(dr["RoundTotal"].ToString());
                s.HandicapDifferential = decimal.Parse(dr["HandicapDifferential"].ToString());
                theScores.Add(s);
            }
            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return theScores;
    }

    public List<Score> SelectScoresForReservation(int reservationID)
    {
        List<Score> theScores = new List<Score>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectScoresForReservation";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ReservationID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = reservationID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            while (dr.Read())
            {
                Score s = new Score();
                s.ReservationID = int.Parse(dr["ReservationID"].ToString());
                s.UserEmail = dr["UserEmail"].ToString();
                s.Scores = new int[18];
                for (int i = 1; i < 18; i++)
                {
                    s.Scores[i - 1] = int.Parse(dr["ScoreHole" + i.ToString()].ToString());
                }
                s.RoundTotal = int.Parse(dr["RoundTotal"].ToString());
                s.HandicapDifferential = decimal.Parse(dr["HandicapDifferential"].ToString());
                theScores.Add(s);
            }
            ClubBAISTConnection.Close();
        }
        catch(Exception e)
        {

        }
        return theScores;
    }

    public List<Score> SelectAllScores()
    {
        List<Score> theScores = new List<Score>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectAllScores";

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            while (dr.Read())
            {
                Score s = new Score();
                s.ReservationID = int.Parse(dr["ReservationID"].ToString());
                s.UserEmail = dr["UserEmail"].ToString();
                s.Scores = new int[18];
                for (int i = 1; i < 18; i++)
                {
                    s.Scores[i - 1] = int.Parse(dr["ScoreHole" + i.ToString()].ToString());
                }
                s.RoundTotal = int.Parse(dr["RoundTotal"].ToString());
                s.HandicapDifferential = decimal.Parse(dr["HandicapDifferential"].ToString());
                theScores.Add(s);
            }
            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return theScores;
    }
}