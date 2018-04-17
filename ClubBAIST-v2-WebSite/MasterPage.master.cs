using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
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
            UserController users = new UserController();
            User u = users.SelectUser(HttpContext.Current.User.Identity.Name);
            userName.Text = "Hi " + u.FirstName + " " + u.LastName + "!";
            if (s.IsInAnyRoles("ADMIN"))
            {
                AdminStuff();
            }
            else
            {
                NotAdminStuff();
            }
            if (s.IsInAnyRoles("Gold", "ADMIN"))
            {
                
            }
            else
            {
                SRLink1.Disabled = true;
                SRLink1.Visible = false;
                SRLink2.Disabled = true;
                SRLink2.Visible = false;
            }
        }
        else
        {
            NotAdminStuff();
        }
    }

    private void NotAdminStuff()
    {
        ALinks.Controls.Clear();
    }

    private void AdminStuff()
    {

    }

    public void Signout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("login.aspx");
    }
}
