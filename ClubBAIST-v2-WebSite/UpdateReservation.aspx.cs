using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateReservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["r"] == null)
        {
            Response.Redirect("ViewReservations.aspx");
        }
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
        ClubBAIST cb = new ClubBAIST();
        Reservation r = cb.ReadReservation(int.Parse(Request.QueryString["r"]));
        Calendar.SelectedDate = r.ReservedTime.Date;
        NumberHolesDD.SelectedValue = r.NumberHoles.ToString();
        NumberCartsDD.SelectedValue = r.NumberCarts.ToString();
        CourseDD.SelectedValue = r.CourseID.ToString();
        Player2TB.Text = r.Player2;
        Player3TB.Text = r.Player3;
        Player4TB.Text = r.Player4;
    }

    protected void DaySelected(object sender, EventArgs e)
    {
        DateTime selectedDay = Calendar.SelectedDate;
        ClubBAIST cb = new ClubBAIST();
        Reservation thisR = cb.ReadReservation(int.Parse(Request.QueryString["r"]));
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
                if (r.ReservedTime == bufferDateTime && r.ReservationID != thisR.ReservationID)
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
        TeeTimesDD.SelectedValue = MakeFormattedDate(thisR.ReservedTime);
    }

    private string MakeFormattedDate(DateTime bufferDateTime)
    {
        string day = bufferDateTime.Day.ToString();
        string month = bufferDateTime.Month.ToString();
        string year = bufferDateTime.Year.ToString();
        string time = bufferDateTime.TimeOfDay.ToString();
        if(int.Parse(bufferDateTime.Month.ToString()) < 10)
        {
            month = String.Format("0{0}", bufferDateTime.Month.ToString());
        }
        if (int.Parse(bufferDateTime.Day.ToString()) < 10)
        {
            day = String.Format("0{0}", bufferDateTime.Day.ToString());
        }


        string formattedDate = String.Format("{0}-{1}-{2} {3}", year, month, day, time);
        return formattedDate;
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        Reservation r = cb.ReadReservation(int.Parse(Request.QueryString["r"]));
        bool b = cb.UpdateReservation(int.Parse(Request.QueryString["r"]), r.UserID, int.Parse(CourseDD.SelectedValue),DateTime.Parse(TeeTimesDD.SelectedValue), int.Parse(NumberHolesDD.SelectedValue), int.Parse(NumberCartsDD.SelectedValue), Player2TB.Text, Player3TB.Text, Player4TB.Text);
        if (!b)
        {
            //Response.Write("Something went wrong.");
        }
        else
        {
            Response.Redirect("ViewReservations.aspx?r=" + r.UserID);
        }
    }
}