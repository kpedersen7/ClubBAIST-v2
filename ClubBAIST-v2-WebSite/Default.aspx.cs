using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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
            MembershipLevelController mlc = new MembershipLevelController();
            List<MembershipLevel> mls = mlc.SelectMembershipLevels();
            bool ok = false;
            foreach(MembershipLevel m in mls)
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
            
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}