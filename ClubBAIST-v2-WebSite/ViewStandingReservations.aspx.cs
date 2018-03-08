using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewStandingReservations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
    }

    private void Authenticate()
    {
        SecurityController s = HttpContext.Current.User as SecurityController;
        if (s != null)
        {
            if (s.IsInRole("ADMIN"))
            {
                FillStandingReservations();
            }
            else
            {
                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }

    private void FillStandingReservations()
    {
        H2Title.InnerText = "Pending Standing Reservation Requests";
        ClubBAIST cb = new ClubBAIST();
        //gets reservations that are not approved(0), but active(1)
        List<StandingReservation> sr = cb.ReadStandingReservations(0,1);
        ListStandingReservations(sr);
    }

    protected void ApprovedReservations_Click(object sender, EventArgs e)
    {
        H2Title.InnerText = "Approved Reservations";
        ClubBAIST cb = new ClubBAIST();
        List<StandingReservation> sr = cb.ReadStandingReservations(1, 1);//get standing reservations that are approved(1) and active (1)
        ListStandingReservations(sr);
    }

    private void ListStandingReservations(List<StandingReservation> sr)
    {
        ClubBAIST cb = new ClubBAIST();
        foreach (StandingReservation s in sr)
        {
            User u = cb.ReadUserByID(s.UserID);
            Course c = cb.ReadCourse(s.CourseID);
            Label l = new Label();
            l.Text = u.FirstName + " " + u.LastName;
            StandingReservations.Controls.Add(l);
            l = new Label();
            l.Text = c.CourseName;
            StandingReservations.Controls.Add(l);
            l = new Label();
            l.Text = s.ReservedTime.ToString();
            StandingReservations.Controls.Add(l);
            l = new Label();
            l.Text = s.EndTime.Date.ToString();
            StandingReservations.Controls.Add(l);
            l = new Label();
            switch (s.NumberHoles)
            {
                case 1:
                    l.Text = "Front 9";
                    break;
                case 2:
                    l.Text = "Back 9";
                    break;
                case 3:
                    l.Text = "18 Holes";
                    break;
            }
            StandingReservations.Controls.Add(l);
            l = new Label();
            l.Text = s.NumberCarts.ToString() + "Carts";
            StandingReservations.Controls.Add(l);
            l = new Label();
            l.Text = "Players: " + s.Player2 + ", " + s.Player3 + ", " + s.Player4;
            StandingReservations.Controls.Add(l);
            LinkButton lb = new LinkButton();
            lb.Text = "Edit";
            lb.Attributes.Add("href", "UpdateStandingReservation.aspx?sr=" + s.StandingReservationID.ToString());
            StandingReservations.Controls.Add(lb);
        }
    }
}