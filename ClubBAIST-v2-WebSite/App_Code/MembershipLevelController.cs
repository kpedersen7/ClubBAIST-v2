using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MembershipLevelController
/// </summary>
public class MembershipLevelController
{
    public bool InsertMembershipLevel(string description)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "InsertMembershipLevel";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Description";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = description;
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

    public MembershipLevel SelectMembershipLevel(int membershipLevelID)
    {
        MembershipLevel ml = new MembershipLevel();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectMembershipLevel";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MembershipLevelID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = membershipLevelID;
            parameter.Direction = ParameterDirection.Input;

            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            dr.Read();

            ml.MembershipLevelID = int.Parse(dr["MembershipLevelID"].ToString());
            ml.Description = dr["Description"].ToString();
            ml.Active = int.Parse(dr["Active"].ToString());

            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return ml;
    }

    public List<MembershipLevel> SelectMembershipLevels()
    {
        List<MembershipLevel> mls = new List<MembershipLevel>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectMembershipLevels";

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();
            while (dr.Read())
            {
                MembershipLevel ml = new MembershipLevel();
                ml.MembershipLevelID = int.Parse(dr["MembershipLevelID"].ToString());
                ml.Description = dr["Description"].ToString();
                ml.Active = int.Parse(dr["Active"].ToString());
                mls.Add(ml);
            }

            ClubBAISTConnection.Close();
        }
        catch
        {

        }
        return mls;
    }

    public bool UpdateMembershipLevel(int membershipLevelID, string description, int active)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "UpdateMembershipLevel";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MembershipLevelID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = membershipLevelID;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Description";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = description;
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

    public bool DeleteMembershipLevel(int membershipLevelID)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAIST"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "DeleteMembershipLevel";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MembershipLevelID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = membershipLevelID;
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