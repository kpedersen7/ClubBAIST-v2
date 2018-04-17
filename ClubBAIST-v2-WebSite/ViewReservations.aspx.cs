using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
//NEED TO RETHINK HOW YOU"RE GONNA DO THIS
//this is a report page so you need filters, admin privilege, etc
//score page has similar issues
public partial class ViewReservations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
        FoundUsers.Visible = false;
    }

    private void Authenticate()
    {
        SecurityController s = HttpContext.Current.User as SecurityController;
        if (s != null)
        {
            ClubBAIST cb = new ClubBAIST();
            List<MembershipLevel> mls = cb.ReadMembershipLevels();
            bool ok = false;
            foreach (MembershipLevel m in mls)
            {
                if (s.IsInRole(m.Description))
                {
                    ok = true;
                }
            }
            if (!ok)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
            if (s.IsInRole("ADMIN"))
            {
                AdminStuff();
            }
            else
            {
                NotAdminStuff();
            }
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }

    private void NotAdminStuff()
    {
        //this guy is not an admin
        MemberSearch.Controls.Clear();
        FoundUsers.Controls.Clear();
        SecurityController s = HttpContext.Current.User as SecurityController;
        ClubBAIST cb = new ClubBAIST();
        User u = cb.ReadUser(s.Identity.Name);
        List<Reservation> userTeeTimes = cb.ReadReservationBatchForMember(u.UserID, s.Identity.Name);
        ListReservations(userTeeTimes);
    }

    private void AdminStuff()
    {
        //this guy is totally admin 
        ClubBAIST cb = new ClubBAIST();
        if (Request.QueryString["u"] != null)
        {
            
            int userID = int.Parse(Request.QueryString["u"]);
            User u = cb.ReadUserByID(userID);
            List<Reservation> reservations = cb.ReadReservationBatchForMember(u.UserID, u.Email);
            ListReservations(reservations);
        }
        else
        {
            List<Reservation> reservations = cb.ReadReservationBatchByTimeFrame(DateTime.Today, DateTime.Today.AddDays(7));
            ListReservations(reservations);
        }

    }

    public void ListReservations(List<Reservation> reservations)
    {
        if (reservations.Count == 0)
        {
            msg.Text = "No reservations to display";
        }
        ClubBAIST cb = new ClubBAIST();
        foreach (Reservation r in reservations)
        {
            User u = cb.ReadUserByID(r.UserID);
            Course c = cb.ReadCourse(r.CourseID);
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = u.FirstName + " " + u.LastName;
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = cb.MakeHumanFriendlyDate(r.ReservedTime);
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = r.ReservedTime.TimeOfDay.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = c.CourseName;
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = r.NumberCarts.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = cb.GetHolesReservationDescription(r.NumberHoles);
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = r.Player2.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = r.Player3.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = r.Player4.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = "Edit";
            lb.Attributes.Add("href", "UpdateReservation.aspx?r=" + r.ReservationID.ToString());
            cell.Controls.Add(lb);
            row.Cells.Add(cell);
            TeeTimesTable.Rows.Add(row);
        }
    }

    protected void UserSearchButton_Click(object sender, EventArgs e)
    {
        FoundUsers.Visible = true;
        ClubBAIST cb = new ClubBAIST();
        List<User> users = cb.SearchUsers(UserSearchTB.Text, UserSearchTB.Text, UserSearchTB.Text, UserSearchTB.Text);
        foreach (User u in users)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = u.FirstName + " " + u.LastName;
            lb.Attributes.Add("href", "ViewReservations.aspx?u=" + u.UserID.ToString());
            cell.Controls.Add(lb);
            row.Cells.Add(cell);
            FoundUsersTable.Rows.Add(row);
        }
    }

    protected void SearchByTimeFrameButton_Click(object sender, EventArgs e)
    {
        while(TeeTimesTable.Rows.Count > 1)
        {
            TeeTimesTable.Rows.RemoveAt(1);
        }
        DateTime minDay = DateTime.Parse(MinDay.Text);
        DateTime maxDay = DateTime.Parse(MaxDay.Text);
        ClubBAIST cb = new ClubBAIST();
        List<Reservation> reservations = cb.ReadReservationBatchByTimeFrame(minDay,maxDay);
        if(Request.QueryString["u"] != null)
        {
            foreach(Reservation r in reservations.ToList())
            {
                if(r.UserID != int.Parse(Request.QueryString["u"]))
                {
                    reservations.Remove(r);
                }
            }
        }
        ListReservations(reservations);
    }
}