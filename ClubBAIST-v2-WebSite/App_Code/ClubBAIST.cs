using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class takes requests from UI and directs them accordingly.
/// </summary>
public class ClubBAIST
{
    #region USER METHODS
    public bool CreateUser(string firstName, string lastName, string phone, string email, string password, int membershipLevelID)
    {
        try
        {
            UserController Users = new UserController();
            bool b = Users.InsertUser(firstName, lastName, phone, email, password, membershipLevelID);
            return b;
        }
        catch
        {
            return false;
        }
    }

    public User ReadUser(string userEmail)
    {
        UserController Users = new UserController();
        User u = Users.SelectUser(userEmail);
        return u;
    }

    public User ReadUserByID(int id)
    {
        UserController Users = new UserController();
        User u = Users.SelectUserByID(id);
        return u;
    }

    public List<User> SearchUsers(string email, string firstname, string lastname, string phone)
    {
        UserController users = new UserController();
        List<User> u = users.SelectUserBatch(email, firstname, lastname, phone);
        return u;
    }

    public bool UpdateUser(int userID, string email, string password, string firstname, string lastname, string phone, int membershipLevelID)
    {
        try
        {
            UserController users = new UserController();
            bool b = users.UpdateUser(userID, email, password, firstname, lastname, phone, membershipLevelID);
            return b;
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
            UserController users = new UserController();
            bool b = users.DeleteUser(userID);
            return b;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region RESERVATION METHODS
    public bool CreateResevation(int userID, int courseID, DateTime reservedTime, int numberHoles, int numberCarts, string player2, string player3, string player4, int isStandingReservation)
    {
        try
        {
            ReservationController reservations = new ReservationController();
            bool b = reservations.InsertReservation(userID, courseID, reservedTime, numberHoles, numberCarts, player2, player3, player4, isStandingReservation);
            return b;
        }
        catch
        {
            return false;
        }
    }

    public Reservation ReadReservation(int reservationID)
    {
        ReservationController reservations = new ReservationController();
        Reservation r = reservations.SelectReservation(reservationID);
        return r;
    }

    public List<Reservation> ReadReservationBatchForMember(int userID, string email)
    {
        ReservationController reservations = new ReservationController();
        List<Reservation> r = reservations.SelectReservationBatchForMember(userID, email);
        return r;
    }

    public List<Reservation> ReadReservationBatchByTimeFrame(DateTime minDay, DateTime maxDay)
    {
        ReservationController reservations = new ReservationController();
        List<Reservation> r = reservations.SelectReservationBatchByTimeFrame(minDay, maxDay);
        return r;
    }

    public bool UpdateReservation(int reservationID, int userID, int courseID, DateTime reservedTime, int numberHoles, int numberCarts, string player2, string player3, string player4)
    {
        try
        {
            ReservationController reservations = new ReservationController();
            bool b = reservations.UpdateReservation(reservationID, userID,courseID,reservedTime,numberHoles,numberCarts, player2, player3, player4);
            return b;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteReservaion(int reservationID)
    {
        try
        {
            ReservationController reservations = new ReservationController();
            bool b = reservations.DeleteReservation(reservationID);
            return b;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region STANDING RESERVATION METHODS
    public bool CreateStandingReservation(int userID, int courseID, DateTime reservedTime, DateTime endTime, int numberHoles, int numberCarts, string player2, string player3, string player4)
    {
        try
        {
            StandingReservationController standingReservations = new StandingReservationController();
            bool b = standingReservations.InsertStandingReservation(userID, courseID, reservedTime, endTime, numberHoles, numberCarts, player2, player3, player4);
            return b;
        }
        catch
        {
            return false;
        }
    }

    public StandingReservation ReadStandingReservation(int standingReservationID)
    {
        StandingReservationController standingReservations = new StandingReservationController();
        StandingReservation sr = standingReservations.SelectStandingReservation(standingReservationID);
        return sr;
    }

    public List<StandingReservation> ReadStandingReservations(int approved, int active)
    {
        StandingReservationController standingReservations = new StandingReservationController();
        List<StandingReservation> sr = standingReservations.SelectStandingReservations(approved, active);
        return sr;
    }

    public bool UpdateStandingReservation(int standingReservationID, int userID, int courseID, DateTime reservedTime, DateTime endTime, int numberHoles, int numberCarts, string player2, string player3, string player4)
    {
        try
        {
            StandingReservationController standingReservations = new StandingReservationController();
            bool b = standingReservations.UpdateStandingReservation(standingReservationID, userID, courseID,reservedTime, endTime, numberHoles, numberCarts, player2, player3, player4);
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
            StandingReservationController standingReservations = new StandingReservationController();
            bool b = standingReservations.UpdateStandingReservationApproval(standingReservationID, approved, active);
            return b;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region MEMBERSHIP LEVEL METHODS
    public bool CreateMembershipLevel(string description)
    {
        try
        {
            MembershipLevelController membershipLevels = new MembershipLevelController();
            bool b = membershipLevels.InsertMembershipLevel(description);
            return b;
        }
        catch
        {
            return false;
        }
    }

    public MembershipLevel ReadMembershipLevel(int membershipLevelID)
    {
        MembershipLevelController membershipLevels = new MembershipLevelController();
        MembershipLevel ml = membershipLevels.SelectMembershipLevel(membershipLevelID);
        return ml;
    }

    public List<MembershipLevel> ReadMembershipLevels()
    {
        MembershipLevelController membershipLevels = new MembershipLevelController();
        List<MembershipLevel> ml = membershipLevels.SelectMembershipLevels();
        return ml;
    }

    public bool UpdateMembershipLevel(int membershipLevelID, string description, int active)
    {
        try
        {
            MembershipLevelController membershipLevels = new MembershipLevelController();
            bool b = membershipLevels.UpdateMembershipLevel(membershipLevelID,description,active);
            return b;
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
            MembershipLevelController membershipLevels = new MembershipLevelController();
            bool b = membershipLevels.DeleteMembershipLevel(membershipLevelID);
            return b;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region COURSE METHODS
    public bool CreateCourse(string courseName, int[] pars, decimal courseRating, decimal slopeRating)
    {
        try
        {
            CourseController courses = new CourseController();
            bool b = courses.InsertCourse(courseName,pars, courseRating,slopeRating);
            return b;
        }
        catch
        {
            return false;
        }
    }

    public Course ReadCourse(int courseID)
    {
        CourseController courses = new CourseController();
        Course c = courses.SelectCourse(courseID);
        return c;
    }

    public List<Course> ReadAllCourses()
    {
        CourseController courses = new CourseController();
        List<Course> cs = courses.SelectAllCourses();
        return cs;
    }

    public bool UpdateCourse(int courseID, string courseName, int[] pars, decimal courseRating, decimal slopeRating)
    {
        try
        {
            CourseController courses = new CourseController();
            bool b = courses.UpdateCourse(courseID, courseName, pars, courseRating,slopeRating);
            return b;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region SCORE METHODS
    public bool CreateScore(int reservationID, string email,int[] theScores, int total)
    {
        try
        {
            ScoreController scores = new ScoreController();
            Reservation r = ReadReservation(reservationID);
            Course c = ReadCourse(r.CourseID);
            decimal handicapDifferential = (decimal.Parse(total.ToString()) - decimal.Parse(c.CourseRating.ToString())) * (113 / decimal.Parse(c.SlopeRating.ToString()));
            bool b = scores.InsertScore(reservationID, email ,theScores, total, handicapDifferential);
            return b;
        }
        catch
        {
            return false;
        }
    }

    public List<Score> ReadScores(string email)
    {
        ScoreController scores = new ScoreController();
        List<Score> s = scores.SelectScores(email);
        return s;
    }

    public List<Score> ReadScoresForReservation(int reservationID)
    {
        ScoreController scores = new ScoreController();
        List<Score> s = scores.SelectScoresForReservation(reservationID);
        return s;
    }

    public List<Score> ReadAllScores()
    {
        ScoreController scores = new ScoreController();
        List<Score> s = scores.SelectAllScores();
        return s;
    }
    #endregion

    #region SECURITY
    public bool IsAuthenticated(string email, string password)
    {
        UserController u = new UserController();
        if(u.IsAuthenticated(email, password))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Helper Methods
    public string MakeHumanFriendlyDate(DateTime d)
    {
        string month = "";
        switch (d.Month)
        {
            case 1:
                month = "January";
                break;
            case 2:
                month = "February";
                break;
            case 3:
                month = "March";
                break;
            case 4:
                month = "April";
                break;
            case 5:
                month = "May";
                break;
            case 6:
                month = "June";
                break;
            case 7:
                month = "July";
                break;
            case 8:
                month = "August";
                break;
            case 9:
                month = "September";
                break;
            case 10:
                month = "October";
                break;
            case 11:
                month = "November";
                break;
            case 12:
                month = "December";
                break;
        }
        return String.Format("{0} {1}, {2}", month, d.Day, d.Year);
    }

    public string GetHolesReservationDescription(int i)
    {
        switch (i)
        {
            case 1:
                return "Front 9";
            case 2:
                return "Back 9";
            case 3:
                return "18 Holes";
            default:
                return "?";
        }
    }
    #endregion
}