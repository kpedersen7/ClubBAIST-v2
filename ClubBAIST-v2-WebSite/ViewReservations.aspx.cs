using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewReservations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
        SecurityController s = HttpContext.Current.User as SecurityController;
        ClubBAIST cb = new ClubBAIST();
        User u = cb.ReadUser(s.Identity.Name);
        List<Reservation> userTeeTimes = cb.ReadReservationBatchForMember(u.UserID);
        foreach(Reservation r in userTeeTimes)
        {
            Label l = new Label();
            l.Text = r.ReservedTime.ToString();
            UpcomingTeeTimes.Controls.Add(l);
            l = new Label();
            l.Text = r.ReservationID.ToString();
            UpcomingTeeTimes.Controls.Add(l);
            LinkButton button = new LinkButton();
            button.Text = "Edit";
            button.Attributes.Add("href", "UpdateReservation.aspx?r="+r.ReservationID.ToString());
            UpcomingTeeTimes.Controls.Add(button);
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
    }

    private void AdminStuff()
    {
        //this guy is totally admin 
        LinkButton lb = new LinkButton();
        lb.Text = "View Standing Reservation Requests";
        lb.Attributes.Add("href","ViewStandingReservations.aspx");
    }
}