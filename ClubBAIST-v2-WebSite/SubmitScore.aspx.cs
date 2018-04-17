using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubmitScore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
        MessageBox.Visible = false;
        ClubBAIST cb = new ClubBAIST();
        if (Request.QueryString["r"] != null)
        {
            if (ScoreExists(HttpContext.Current.User.Identity.Name))
            {
                MessageBox.Visible = true;
            }
            else
            {
                MessageBox.Visible = false;
            }
            int reservationID = int.Parse(Request.QueryString["r"]);
            Reservation r = cb.ReadReservation(reservationID);
            User u = cb.ReadUserByID(r.UserID);
            Course c = cb.ReadCourse(r.CourseID);
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = r.ReservedTime.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = u.FirstName + " " + u.LastName;
            if (ScoreExists(u.Email))
            {
                cell.Attributes.Add("style", "background-color:#a0ff6d;");
            }
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = c.CourseName.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = r.NumberCarts.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = cb.GetHolesReservationDescription(r.NumberHoles);
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = String.Format(r.Player2);
            if(r.Player2.Trim() != "" && r.Player2 != null)
            {
                if (ScoreExists(r.Player2))
                {
                    cell.Attributes.Add("style", "background-color:#a0ff6d;");
                }
            }
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = String.Format(r.Player3);
            if (r.Player3.Trim() != "" && r.Player3 != null)
            {
                if (ScoreExists(r.Player3))
                {
                    cell.Attributes.Add("style", "background-color:#a0ff6d;");
                }
            }
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = String.Format(r.Player4);
            if (r.Player4.Trim() != "" && r.Player4 != null)
            {
                if (ScoreExists(r.Player2))
                {
                    cell.Attributes.Add("style", "background-color:#a0ff6d;");
                }
            }
            row.Cells.Add(cell);
            ThisReservation.Rows.Add(row);

            PageControls.Controls.Remove(FoundUsersTable);
            PageControls.Controls.Remove(FoundUsersTableLabel);
            PageControls.Controls.Remove(ReservationsTable);
            PageControls.Controls.Remove(ReservationsTableLabel);
            PageControls.Controls.Remove(FoundUsersTableLabel);
            PageControls.Controls.Remove(FoundUsersTable);
            PageControls.Controls.Remove(SearchTable);

            DisableUnusedHoles(r.NumberHoles);
        }
        else
        {

            PageControls.Controls.Remove(ThisReservation);
            PageControls.Controls.Remove(ThisReservationTableLabel);
            PageControls.Controls.Remove(HoleScoresTableLabel);
            PageControls.Controls.Remove(HoleScoresTable);
            PageControls.Controls.Remove(SubmitButton);
            SelectUserTable.Visible = false;

            if (Request.QueryString["u"] != null)
            {
                FoundUsersTableLabel.Visible = false;
            }
            else
            {
                ReservationsTableLabel.Visible = false;
            }
        }
    }

    private void Authenticate()
    {
        SecurityController s = HttpContext.Current.User as SecurityController;
        ClubBAIST cb = new ClubBAIST();
        if (s != null)
        {
            if (s.IsInAnyRoles("ADMIN"))
            {
                AdminStuff();
            }
            else
            {
                NotAdminStuff();
            }
            if (!s.IsInAnyRoles("ADMIN", "Gold", "Silver", "Bronze"))
            {
                Response.Redirect("Default.aspx");
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
        PageControls.Controls.Remove(FoundUsersTableLabel);
        PageControls.Controls.Remove(FoundUsersTable);
        PageControls.Controls.Remove(SearchTable);
        PageControls.Controls.Remove(SelectUserTable);
        ClubBAIST cb = new ClubBAIST();
        User u = cb.ReadUser(HttpContext.Current.User.Identity.Name);
        if (Request.QueryString["r"] != null)
        {
            Reservation r = cb.ReadReservation(int.Parse(Request.QueryString["r"]));
            if (u.UserID != r.UserID && u.Email != r.Player2 && u.Email != r.Player3 && u.Email != r.Player4)
            {
                Response.Redirect("SubmitScore.aspx");
            }
        }
        else
        {
            ListReservationsForUser(u.UserID);
        }

    }

    private void AdminStuff()
    {
        ClubBAIST cb = new ClubBAIST();
        if (Request.QueryString["u"] != null)
        {
            PageControls.Controls.Remove(SelectUserTable);
            User u = cb.ReadUserByID(int.Parse(Request.QueryString["u"]));
            ListReservationsForUser(u.UserID);
        }
        else
        {
            if (Request.QueryString["r"] != null)
            {
                //fill UsersOnReservationDD with players on the reservation
                Reservation r = cb.ReadReservation(int.Parse(Request.QueryString["r"]));
                User u = cb.ReadUserByID(r.UserID);
                ListItem li = new ListItem();
                li.Text = u.FirstName + " " + u.LastName;
                li.Value = u.Email;
                UsersOnReservationDD.Items.Add(li);
                if (r.Player2 != null && r.Player2.Trim() != "")
                {
                    u = cb.ReadUser(r.Player2);
                    li = new ListItem();
                    li.Text = u.FirstName + " " + u.LastName;
                    li.Value = u.Email;
                    UsersOnReservationDD.Items.Add(li);
                }
                if (r.Player3 != null && r.Player3.Trim() != "")
                {
                    u = cb.ReadUser(r.Player3);
                    li = new ListItem();
                    li.Text = u.FirstName + " " + u.LastName;
                    li.Value = u.Email;
                    UsersOnReservationDD.Items.Add(li);
                }
                if (r.Player4 != null && r.Player4.Trim() != "")
                {
                    u = cb.ReadUser(r.Player4);
                    li = new ListItem();
                    li.Text = u.FirstName + " " + u.LastName;
                    li.Value = u.Email;
                    UsersOnReservationDD.Items.Add(li);
                }
            }
        }
    }

    protected void UserSearchButton_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        List<User> users = cb.SearchUsers(UserSearchTB.Text, UserSearchTB.Text, UserSearchTB.Text, UserSearchTB.Text);
        foreach (User u in users)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            LinkButton lb = new LinkButton();
            lb.Text = u.FirstName + " " + u.LastName;
            lb.Attributes.Add("href", "SubmitScore.aspx?u=" + u.UserID.ToString());
            cell.Controls.Add(lb);
            row.Cells.Add(cell);
            FoundUsersTable.Rows.Add(row);
        }
    }

    private void ListReservationsForUser(int userID)
    {
        ClubBAIST cb = new ClubBAIST();
        List<Reservation> reservations = cb.ReadReservationBatchForMember(userID, HttpContext.Current.User.Identity.Name);
        foreach (Reservation r in reservations)
        {
            if (DateTime.Compare(r.ReservedTime, DateTime.Today) < 0)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                LinkButton lb = new LinkButton();
                lb.Text = r.ReservedTime.ToString();
                lb.Attributes.Add("href", "SubmitScore.aspx?r=" + r.ReservationID);
                cell.Controls.Add(lb);
                row.Cells.Add(cell);
                ReservationsTable.Rows.Add(row);
            }
        }
        PageControls.Controls.Remove(FoundUsersTableLabel);
        PageControls.Controls.Remove(FoundUsersTable);
        PageControls.Controls.Remove(HoleScoresTable);
        PageControls.Controls.Remove(HoleScoresTableLabel);
        PageControls.Controls.Remove(SubmitButton);
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        int[] scores = new int[18];
        scores[0] = int.Parse(Par1.SelectedValue);
        scores[1] = int.Parse(Par2.SelectedValue);
        scores[2] = int.Parse(Par3.SelectedValue);
        scores[3] = int.Parse(Par4.SelectedValue);
        scores[4] = int.Parse(Par5.SelectedValue);
        scores[5] = int.Parse(Par6.SelectedValue);
        scores[6] = int.Parse(Par7.SelectedValue);
        scores[7] = int.Parse(Par8.SelectedValue);
        scores[8] = int.Parse(Par9.SelectedValue);
        scores[9] = int.Parse(Par10.SelectedValue);
        scores[10] = int.Parse(Par11.SelectedValue);
        scores[11] = int.Parse(Par12.SelectedValue);
        scores[12] = int.Parse(Par13.SelectedValue);
        scores[13] = int.Parse(Par14.SelectedValue);
        scores[14] = int.Parse(Par15.SelectedValue);
        scores[15] = int.Parse(Par16.SelectedValue);
        scores[16] = int.Parse(Par17.SelectedValue);
        scores[17] = int.Parse(Par18.SelectedValue);
        int total = 0;
        for(int i = 0; i < scores.Length; i++)
        {
            total = total + scores[i];
        }
        string email = UsersOnReservationDD.SelectedValue;
        ClubBAIST cb = new ClubBAIST();
        SecurityController s = HttpContext.Current.User as SecurityController;
        bool b;
        if (s != null)
        {
            if (Request.QueryString["r"] != null)
            {
                if (s.IsInAnyRoles("ADMIN"))
                {
                    b = cb.CreateScore(int.Parse(Request.QueryString["r"]), email, scores, total);
                    Response.Redirect("Default.aspx");
                }
                else
                {

                    User u = cb.ReadUser(HttpContext.Current.User.Identity.Name);
                    b = cb.CreateScore(int.Parse(Request.QueryString["r"]), u.Email, scores, total);
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }

    private bool ScoreExists(string email)
    {
        ClubBAIST cb = new ClubBAIST();
        Reservation r = cb.ReadReservation(int.Parse(Request.QueryString["r"]));
        User u = cb.ReadUser(email);
        bool exists = false;
        if (u.Email != null)
        {
            List<Score> scoresForThisReservation = cb.ReadScoresForReservation(r.ReservationID);
            foreach (Score s in scoresForThisReservation)
            {
                if (s.UserEmail == u.Email || s.UserEmail == r.Player2 || s.UserEmail == r.Player3 || s.UserEmail == r.Player4)
                {
                    exists = true;
                }
            }
            
        }
        return exists;
    }

    private void DisableUnusedHoles(int numberHoles)
    {
        switch (numberHoles)
        {
            case 1:
                Par10.Enabled = false;
                Par11.Enabled = false;
                Par12.Enabled = false;
                Par13.Enabled = false;
                Par14.Enabled = false;
                Par15.Enabled = false;
                Par16.Enabled = false;
                Par17.Enabled = false;
                Par18.Enabled = false;
                break;
            case 2:
                Par1.Enabled = false;
                Par2.Enabled = false;
                Par3.Enabled = false;
                Par4.Enabled = false;
                Par5.Enabled = false;
                Par6.Enabled = false;
                Par7.Enabled = false;
                Par8.Enabled = false;
                Par9.Enabled = false;
                break;
        }
    }
}