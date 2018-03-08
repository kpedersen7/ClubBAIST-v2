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
    public bool InsertScore(int userID, int courseID, int[] scores)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "InsertScore";

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

    public List<Score> SelectScores(int userID)
    {
        List<Score> theScores = new List<Score>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectScores";

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
                Score s = new Score();
                s.CourseID = int.Parse(dr["CourseID"].ToString());
                s.UserID = int.Parse(dr["UserID"].ToString());
                for (int i = 1; i < 18; i++)
                {
                    s.Scores[i - 1] = int.Parse(dr["Score" + i.ToString()].ToString());
                }
            }
            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return theScores;
    }
}