using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewScores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
        
    }

    private void ListScores(List<Score> userScores)
    {
        ClubBAIST cb = new ClubBAIST();
        foreach (Score sc in userScores)
        {
            Reservation r = cb.ReadReservation(sc.ReservationID);
            Course course = cb.ReadCourse(r.CourseID);
            //use sc to get score info, total score
            TableRow tr = new TableRow();
            TableCell c = new TableCell();
            c.Text = cb.MakeHumanFriendlyDate(r.ReservedTime);
            tr.Cells.Add(c);
            c = new TableCell();
            c.Text = r.ReservedTime.TimeOfDay.ToString();
            tr.Cells.Add(c);
            c = new TableCell();
            c.Text = course.CourseName;
            tr.Cells.Add(c);
            c = new TableCell();
            c.Text = sc.RoundTotal.ToString();
            tr.Cells.Add(c);
            c = new TableCell();
            c.Text = sc.HandicapDifferential.ToString();
            tr.Cells.Add(c);
            ScoresTable.Rows.Add(tr);
            //button to view whole score breakdown?
        }
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
        MemberSearch.Controls.Remove(SearchTable);
        FoundUsers.Controls.Remove(FoundUsersTable);
        FoundUsers.Controls.Remove(FoundUsersTableLabel);
        SecurityController s = HttpContext.Current.User as SecurityController;
        ClubBAIST cb = new ClubBAIST();
        User u = cb.ReadUser(s.Identity.Name);
        List<Score> userScores = cb.ReadScores(u.Email);
        ListScores(userScores);
    }

    private void AdminStuff()
    {
        //this guy is totally admin 
        ClubBAIST cb = new ClubBAIST();
        if (Request.QueryString["u"] != null)
        {
            int userID = int.Parse(Request.QueryString["u"]);
            User u = cb.ReadUserByID(userID);
            List<Score> userScores = cb.ReadScores(u.Email);
            ListScores(userScores);
        }
        else
        {
            List<Score> allScores = cb.ReadAllScores();
            ListScores(allScores);
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
            lb.Attributes.Add("href", "ViewScores.aspx?u=" + u.UserID.ToString());
            cell.Controls.Add(lb);
            row.Cells.Add(cell);
            FoundUsersTable.Rows.Add(row);
        }
    }
}