using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for UserController
/// </summary>
public class UserController
{
    public bool InsertUser(string firstName, string lastName, string phone, string email, string password, int membershipLevelID)
    {
        try
        {
            string salt = MakeSalt();

            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "InsertUser";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserEmail";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = email;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Password";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = HashMaster(password, salt);
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@FirstName";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = firstName;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@LastName";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = lastName;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Phone";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = phone;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Salt";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = salt;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
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
        catch(Exception e)
        {
            return false;
        }
    }

    public User SelectUser(string userEmail)
    {
        User theUser = new User();

        SqlConnection ClubBAISTConnection = new SqlConnection();
        ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

        SqlCommand ClubBAISTCommand = new SqlCommand();
        ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
        ClubBAISTCommand.Connection = ClubBAISTConnection;
        ClubBAISTCommand.CommandText = "SelectUser";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@UserEmail";
        parameter.SqlDbType = SqlDbType.NChar;
        parameter.Value = userEmail;
        parameter.Direction = ParameterDirection.Input;

        ClubBAISTCommand.Parameters.Add(parameter);

        ClubBAISTConnection.Open();
        SqlDataReader dr;
        dr = ClubBAISTCommand.ExecuteReader();
        dr.Read();

        theUser.UserID = int.Parse(dr["UserID"].ToString());
        theUser.Salt = dr["Salt"].ToString();
        theUser.Email = dr["UserEmail"].ToString();
        theUser.Password = dr["Password"].ToString();
        theUser.MembershipLevel = int.Parse(dr["MembershipLevelID"].ToString());
        theUser.FirstName = dr["FirstName"].ToString();
        theUser.LastName = dr["LastName"].ToString();
        theUser.Phone = dr["Phone"].ToString();

        ClubBAISTConnection.Close();

        return theUser;
    }

    public User SelectUserByID(int id)
    {
        User theUser = new User();

        SqlConnection ClubBAISTConnection = new SqlConnection();
        ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

        SqlCommand ClubBAISTCommand = new SqlCommand();
        ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
        ClubBAISTCommand.Connection = ClubBAISTConnection;
        ClubBAISTCommand.CommandText = "SelectUserByID";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@UserID";
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = id;
        parameter.Direction = ParameterDirection.Input;

        ClubBAISTCommand.Parameters.Add(parameter);

        ClubBAISTConnection.Open();
        SqlDataReader dr;
        dr = ClubBAISTCommand.ExecuteReader();
        dr.Read();

        theUser.UserID = int.Parse(dr["UserID"].ToString());
        theUser.Salt = dr["Salt"].ToString();
        theUser.Email = dr["UserEmail"].ToString();
        theUser.Password = dr["Password"].ToString();
        theUser.MembershipLevel = int.Parse(dr["MembershipLevelID"].ToString());
        theUser.FirstName = dr["FirstName"].ToString();
        theUser.LastName = dr["LastName"].ToString();
        theUser.Phone = dr["Phone"].ToString();

        ClubBAISTConnection.Close();

        return theUser;
    }

    public List<User> SelectUserBatch(string email, string firstname, string lastname, string phone)
    {
        List<User> theUsers = new List<User>();
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "SelectUserBatch";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserEmail";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = email;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@FirstName";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = firstname;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@LastName";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = lastname;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Phone";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = phone;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            ClubBAISTConnection.Open();
            SqlDataReader dr;
            dr = ClubBAISTCommand.ExecuteReader();

            while (dr.Read())
            {
                User u = new User();
                u.UserID = int.Parse(dr["UserID"].ToString());
                u.Salt = dr["Salt"].ToString();
                u.Email = dr["UserEmail"].ToString();
                u.Password = dr["Password"].ToString();
                u.MembershipLevel = int.Parse(dr["MembershipLevelID"].ToString());
                u.FirstName = dr["FirstName"].ToString();
                u.LastName = dr["LastName"].ToString();
                u.Phone = dr["Phone"].ToString();
                theUsers.Add(u);
            }

            ClubBAISTConnection.Close();
        }
        catch
        {
            return theUsers;
        }

        return theUsers;
    }

    public bool UpdateUser(int userID, string email, string password, string firstname, string lastname, string phone, int membershipLevelID)
    {
        try
        {
            string salt = MakeSalt();

            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "UpdateUser";

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

            parameter = new SqlParameter();
            parameter.ParameterName = "@Password";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = HashMaster(password, salt);
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@FirstName";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = firstname;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@LastName";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = lastname;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Phone";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = phone;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Salt";
            parameter.SqlDbType = SqlDbType.NChar;
            parameter.Value = salt;
            parameter.Direction = ParameterDirection.Input;
            ClubBAISTCommand.Parameters.Add(parameter);

            parameter = new SqlParameter();
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

    public bool DeleteUser(int userID)
    {
        try
        {
            SqlConnection ClubBAISTConnection = new SqlConnection();
            ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

            SqlCommand ClubBAISTCommand = new SqlCommand();
            ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
            ClubBAISTCommand.Connection = ClubBAISTConnection;
            ClubBAISTCommand.CommandText = "DeleteUser";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = userID;
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

    public string HashMaster(string textForHash, string salt)
    {
        SHA1Managed sha1 = new SHA1Managed();
        textForHash = textForHash + salt;
        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(textForHash));
        return Convert.ToBase64String(hash);
    }

    public string MakeSalt()
    {
        RNGCryptoServiceProvider cryptoNinja = new RNGCryptoServiceProvider();
        byte[] salt = new byte[5];
        cryptoNinja.GetBytes(salt);
        return Convert.ToBase64String(salt);
    }

    public bool IsAuthenticated(string email, string password)
    {
        SqlConnection ClubBAISTConnection = new SqlConnection();
        ClubBAISTConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ClubBAISTLaptop"].ConnectionString;

        SqlCommand ClubBAISTCommand = new SqlCommand();
        ClubBAISTCommand.CommandType = CommandType.StoredProcedure;
        ClubBAISTCommand.Connection = ClubBAISTConnection;
        ClubBAISTCommand.CommandText = "SelectUser";

        SqlParameter userEmail = new SqlParameter();
        userEmail.ParameterName = "@UserEmail";
        userEmail.SqlDbType = SqlDbType.NChar;
        userEmail.Value = email;
        userEmail.Direction = ParameterDirection.Input;

        ClubBAISTCommand.Parameters.Add(userEmail);

        ClubBAISTConnection.Open();
        SqlDataReader dr;
        dr = ClubBAISTCommand.ExecuteReader();
        dr.Read();
        string salt = dr["Salt"].ToString();
        string foundEmail = dr["UserEmail"].ToString();
        string foundPassword = dr["Password"].ToString();
        ClubBAISTConnection.Close();

        if ((email == foundEmail) && (HashMaster(password, salt) == foundPassword))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}