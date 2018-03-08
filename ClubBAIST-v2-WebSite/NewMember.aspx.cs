using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillMemberShipLevels();
        }
    }

    private void FillMemberShipLevels()
    {
        MembershipLevelDD.Items.Clear();
        ClubBAIST cb = new ClubBAIST();
        List<MembershipLevel> mls = cb.ReadMembershipLevels();
        foreach(MembershipLevel ml in mls)
        {
            ListItem li = new ListItem();
            li.Text = ml.Description;
            li.Value = ml.MembershipLevelID.ToString();
            MembershipLevelDD.Items.Add(li);
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        Response.Write(MembershipLevelDD.SelectedValue);
        //bool b = cb.CreateUser(FirstNameTB.Text, LastNameTB.Text, PhoneTB.Text, EmailTB.Text, PasswordTB.Text, int.Parse(MembershipLevelDD.SelectedValue));
        //if (b)
        //{
        //    //User feedback
        //}
    }
}