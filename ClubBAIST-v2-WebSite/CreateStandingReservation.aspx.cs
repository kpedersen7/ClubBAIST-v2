using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateStandingReservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
        if (!Page.IsPostBack)
        {
            Calendar.SelectedDate = DateTime.Today;
            DaySelected(sender, e);
            FillCourseDropDown();
        }
    }

    private void Authenticate()
    {
        SecurityController s = HttpContext.Current.User as SecurityController;
        if (s != null)
        {
            if (!s.IsInAnyRoles("ADMIN", "Gold"))
            {
                Response.Redirect("Default.aspx");
            }
            if (s.IsInAnyRoles("ADMIN"))
            {

            }
            else
            {
                AdminStuff();
            }
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }

    private void AdminStuff()
    {
        AStuff.Controls.Clear();
    }

    protected void DaySelected(object sender, EventArgs e)
    {
        DateTime selectedDay = Calendar.SelectedDate;
        if (selectedDay < DateTime.Today)
        {
            msg.Text = "you can't book in the past";
            Calendar.SelectedDate = DateTime.Today;
        }
        ClubBAIST cb = new ClubBAIST();
        List<Reservation> TeeTimesForDay = cb.ReadReservationBatchByTimeFrame(selectedDay, selectedDay.AddDays(1));
        TeeTimesDD.Items.Clear();
        DateTime bufferDateTime = selectedDay.AddHours(7.00);
        bool offset = true;
        while (bufferDateTime <= selectedDay.AddHours(18))
        {
            ListItem li = new ListItem();
            li.Text = bufferDateTime.TimeOfDay.ToString();
            li.Value = MakeFormattedDate(bufferDateTime);

            foreach (Reservation r in TeeTimesForDay)
            {
                if (r.ReservedTime == bufferDateTime)
                {
                    li.Attributes.Add("disabled", "true");
                }
            }
            TeeTimesDD.Items.Add(li);
            if (offset)
            {
                bufferDateTime = bufferDateTime.AddMinutes(7.00);
                offset = false;
            }
            else
            {
                bufferDateTime = bufferDateTime.AddMinutes(8.00);
                offset = true;
            }
        }
    }

    private string MakeFormattedDate(DateTime bufferDateTime)
    {
        string day = bufferDateTime.Day.ToString();
        string month = bufferDateTime.Month.ToString();
        string year = bufferDateTime.Year.ToString();
        string time = bufferDateTime.TimeOfDay.ToString();

        string formattedDate = String.Format("{0}-{1}-{2} {3}", year, month, day, time);
        return formattedDate;
    }

    private void FillCourseDropDown()
    {
        CourseDD.Items.Clear();
        ClubBAIST cb = new ClubBAIST();
        List<Course> cs = cb.ReadAllCourses();
        foreach (Course c in cs)
        {
            ListItem li = new ListItem();
            li.Text = c.CourseName;
            li.Value = c.CourseID.ToString();
            CourseDD.Items.Add(li);
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        User u = cb.ReadUser(HttpContext.Current.User.Identity.Name);
        bool b;
        SecurityController s = HttpContext.Current.User as SecurityController;
        if (s != null)
        {
            if (s.IsInAnyRoles("ADMIN"))
            {
                b = cb.CreateStandingReservation(int.Parse(Request.QueryString["u"]), int.Parse(CourseDD.SelectedValue), DateTime.Parse(TeeTimesDD.SelectedValue), EndCalendar.SelectedDate, int.Parse(NumberHolesDD.SelectedValue), int.Parse(NumberCartsDD.SelectedValue), Player2TB.Text, Player3TB.Text, Player4TB.Text);
                Response.Redirect("Default.aspx");
            }
            else
            {
                b = cb.CreateStandingReservation(u.UserID, int.Parse(CourseDD.SelectedValue), DateTime.Parse(TeeTimesDD.SelectedValue), EndCalendar.SelectedDate, int.Parse(NumberHolesDD.SelectedValue), int.Parse(NumberCartsDD.SelectedValue), Player2TB.Text, Player3TB.Text, Player4TB.Text);
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void UserSearchButton_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        List<User> users = cb.SearchUsers(UserSearchTB.Text, UserSearchTB.Text, UserSearchTB.Text, UserSearchTB.Text);
        foreach (User u in users)
        {
            LinkButton lb = new LinkButton();
            lb.Text = u.FirstName + " " + u.LastName;
            lb.Attributes.Add("href", "CreateStandingReservation.aspx?u=" + u.UserID.ToString());
            AStuff.Controls.Add(lb);
        }
    }
}