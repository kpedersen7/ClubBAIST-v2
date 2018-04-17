using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateStandingReservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCourseDropDown();
            FillForm();
            DaySelected(sender, e);
        }
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

    private void FillForm()
    {
        //this page will break
        ClubBAIST cb = new ClubBAIST();
        StandingReservation sr = cb.ReadStandingReservation(int.Parse(Request.QueryString["sr"]));
        Calendar.SelectedDate = sr.ReservedTime.Date;
        EndCalendar.SelectedDate = sr.EndTime.Date;
        EndCalendar.VisibleDate = sr.EndTime.Date;
        NumberHolesDD.SelectedValue = sr.NumberHoles.ToString();
        NumberCartsDD.SelectedValue = sr.NumberCarts.ToString();
        CourseDD.SelectedValue = sr.CourseID.ToString();
        Player2TB.Text = sr.Player2;
        Player3TB.Text = sr.Player3;
        Player4TB.Text = sr.Player4;
    }

    protected void DaySelected(object sender, EventArgs e)
    {
        DateTime selectedDay = Calendar.SelectedDate;
        ClubBAIST cb = new ClubBAIST();
        StandingReservation sr = cb.ReadStandingReservation(int.Parse(Request.QueryString["sr"]));
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
        TeeTimesDD.SelectedValue = MakeFormattedDate(sr.ReservedTime);
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

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        StandingReservation sr = cb.ReadStandingReservation(int.Parse(Request.QueryString["sr"]));
        bool b = cb.UpdateStandingReservation(int.Parse(Request.QueryString["sr"]), sr.UserID, int.Parse(CourseDD.SelectedValue), DateTime.Parse(TeeTimesDD.SelectedValue), EndCalendar.SelectedDate, int.Parse(NumberHolesDD.SelectedValue), int.Parse(NumberCartsDD.SelectedValue), Player2TB.Text, Player3TB.Text, Player4TB.Text);
        if (!b)
        {
            Response.Write("Something went wrong.");
        }
        else
        {
            Response.Redirect("ViewStandingReservations.aspx");
        }
    }

    protected void Approve_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        StandingReservation sr = cb.ReadStandingReservation(int.Parse(Request.QueryString["sr"]));
        bool b = cb.UpdateStandingReservationApproval(sr.StandingReservationID,1, 1);
        if (!b)
        {

        }
    }
}