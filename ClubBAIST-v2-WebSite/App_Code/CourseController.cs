using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseController
/// </summary>
public class CourseController 
{
    public bool InsertCourse(string courseName, int[] pars, decimal courseRating, decimal slopeRating)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "InsertCourse";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@CourseName";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = courseName;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            for(int i = 0; i < pars.Length; i++)
            {
                parameter = new SqlParameter();
                parameter.ParameterName = "@Par" + (i+1).ToString();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = pars[i];
                parameter.Direction = ParameterDirection.Input;
                ClubBAISTCommand.Parameters.Add(parameter);
            }

            parameter = new SqlParameter();
            parameter.ParameterName = "@CourseRating";
            parameter.SqlDbType = SqlDbType.Decimal;
            parameter.Value = courseRating;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@SlopeRating";
            parameter.SqlDbType = SqlDbType.Decimal;
            parameter.Value = slopeRating;
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

    public Course SelectCourse(int courseID)
    {
        Course c = new Course();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectCourse";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@CourseID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = courseID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            dr.Read();
            c.CourseID = int.Parse(dr["CourseID"].ToString());
            c.CourseName = dr["CourseName"].ToString();
            c.CourseRating = decimal.Parse(dr["CourseRating"].ToString());
            c.SlopeRating = decimal.Parse(dr["SlopeRating"].ToString());
            for (int i = 1; i < 18; i++)
            {
                c.Pars[i-1] = int.Parse(dr["ParHole" + i.ToString()].ToString());
            }
            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return c;
    }

    public List<Course> SelectAllCourses()
    {
        List<Course> courses = new List<Course>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectAllCourses";

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            while (dr.Read())
            {
                Course c = new Course();
                c.CourseID = int.Parse(dr["CourseID"].ToString());
                c.CourseName = dr["CourseName"].ToString();
                c.CourseRating = decimal.Parse(dr["CourseRating"].ToString());
                c.SlopeRating = decimal.Parse(dr["SlopeRating"].ToString());
                c.Pars = new int[18];
                for (int i = 0; i < 17; i++)
                {
                    c.Pars[i] = int.Parse(dr["ParHole" + (i+1).ToString()].ToString());
                }
                courses.Add(c);
            }
            ClubBAISTConnection.Close();
        }
        catch(Exception e)
        {

        }
        return courses;
    }

    public bool UpdateCourse(int courseID, string courseName, int[] pars, decimal courseRating, decimal slopeRating)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "UpdateCourse";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@CourseID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = courseID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@CourseName";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = courseName;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            foreach(int i in pars)
            {
                int j = 1;
                parameter = new SqlParameter();
                parameter.ParameterName = "@ParHole" + j;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = i;
                parameter.Direction = ParameterDirection.Input;
                ClubBAISTCommand.Parameters.Add(parameter);
                j++;
            }

            parameter = new SqlParameter();
            parameter.ParameterName = "@CourseRating";
            parameter.SqlDbType = SqlDbType.Decimal;
            parameter.Value = courseRating;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@SlopeRating";
            parameter.SqlDbType = SqlDbType.Decimal;
            parameter.Value = slopeRating;
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