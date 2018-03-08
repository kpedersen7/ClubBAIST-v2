using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        if(cb.IsAuthenticated(UserEmail.Text, Password.Text))
        {
            User thisUser = cb.ReadUser(UserEmail.Text);
            MembershipLevel ml = cb.ReadMembershipLevel(thisUser.MembershipLevel);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, UserEmail.Text, DateTime.Now, DateTime.Now.AddMinutes(30), false, ml.Description);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            Response.Redirect(FormsAuthentication.GetRedirectUrl(UserEmail.Text, false));
        }
        else
        {
            Msg.Text = "Login failed, check username or password.";
        }
    }
}