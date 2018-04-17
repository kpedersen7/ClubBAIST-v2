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
        if (!Page.IsPostBack)
        {

        }
    }

    private void Authenticate()
    {
        SecurityController s = HttpContext.Current.User as SecurityController;
        if (s != null)
        {
            if (s.IsInRole("ADMIN"))
            {

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
        List<StandingReservation> sr = cb.ReadStandingReservations(1, 1);//gets standing reservations that are approved(1) and active (1)
        ListStandingReservations(sr);
        ApprovedReservationsButton.Visible = false;
        ApprovedReservationsButton.Enabled = false;
        PendingReservationsButton.Visible = true;
        PendingReservationsButton.Enabled = true;
    }

    protected void PendingReservations_Click(object sender, EventArgs e)
    {
        H2Title.InnerText = "Pending Standing Reservation Requests";
        ClubBAIST cb = new ClubBAIST();
        List<StandingReservation> sr = cb.ReadStandingReservations(0, 1); //gets standing reservations that are not approved(0), but active(1)
        ListStandingReservations(sr);
        PendingReservationsButton.Visible = false;
        PendingReservationsButton.Enabled = false;
        ApprovedReservationsButton.Visible = true;
        ApprovedReservationsButton.Enabled = true;
    }

    private void ListStandingReservations(List<StandingReservation> sr)
    {
        for(int i = 1; i < StandingReservationsTable.Rows.Count; i++)
        {
            StandingReservationsTable.Rows.RemoveAt(i);//remove all table rows except the header
        }
        ClubBAIST cb = new ClubBAIST();
        foreach (StandingReservation s in sr)
        {
            User u = cb.ReadUserByID(s.UserID);
            Course c = cb.ReadCourse(s.CourseID);
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = u.FirstName + " " + u.LastName;
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = c.CourseName;
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = cb.MakeHumanFriendlyDate(s.ReservedTime);
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = cb.MakeHumanFriendlyDate(s.EndTime);
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = s.ReservedTime.DayOfWeek.ToString() + "s, " + s.ReservedTime.TimeOfDay.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = cb.GetHolesReservationDescription(s.NumberHoles);
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = s.NumberCarts.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = s.Player2;
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = s.Player3;
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = s.Player4;
            row.Cells.Add(cell);
            cell = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = "Edit";
            lb.Attributes.Add("href", "UpdateStandingReservation.aspx?sr=" + s.StandingReservationID.ToString());
            cell.Controls.Add(lb);
            row.Cells.Add(cell);
            StandingReservationsTable.Rows.Add(row);
        }
    }
}