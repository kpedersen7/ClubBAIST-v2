using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubmitScore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
        if (!Page.IsPostBack)
        {
            FillCourseDropDown();
        }
    }

    private void Authenticate()
    {
        SecurityController s = HttpContext.Current.User as SecurityController;
        if (s != null)
        {
            if (s.IsInAnyRoles("ADMIN", "Gold", "Silver", "Bronze"))
            {

            }
            else
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

        ClubBAIST cb = new ClubBAIST();
        bool b;
        SecurityController s = HttpContext.Current.User as SecurityController;
        if (s != null)
        {
            if (s.IsInAnyRoles("ADMIN"))
            {

                b = cb.CreateScore(int.Parse(Request.QueryString["u"]), int.Parse(CourseDD.SelectedValue), scores);
                Response.Redirect("Default.aspx");
            }
            else
            {
                User u = cb.ReadUser(HttpContext.Current.User.Identity.Name);
                b = cb.CreateScore(u.UserID, int.Parse(CourseDD.SelectedValue), scores);
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
            lb.Attributes.Add("href", "SubmitScore.aspx?u=" + u.UserID.ToString());
            AStuff.Controls.Add(lb);
        }
    }


}