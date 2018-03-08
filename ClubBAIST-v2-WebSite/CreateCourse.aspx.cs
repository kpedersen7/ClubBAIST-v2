using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        ClubBAIST cb = new ClubBAIST();
        int[] pars = new int[18];
        pars[0] = int.Parse(Par1.SelectedValue);
        pars[1] = int.Parse(Par2.SelectedValue);
        pars[2] = int.Parse(Par3.SelectedValue);
        pars[3] = int.Parse(Par4.SelectedValue);
        pars[4] = int.Parse(Par5.SelectedValue);
        pars[5] = int.Parse(Par6.SelectedValue);
        pars[6] = int.Parse(Par7.SelectedValue);
        pars[7] = int.Parse(Par8.SelectedValue);
        pars[8] = int.Parse(Par9.SelectedValue);
        pars[9] = int.Parse(Par10.SelectedValue);
        pars[10] = int.Parse(Par11.SelectedValue);
        pars[11] = int.Parse(Par12.SelectedValue);
        pars[12] = int.Parse(Par13.SelectedValue);
        pars[13] = int.Parse(Par14.SelectedValue);
        pars[14] = int.Parse(Par15.SelectedValue);
        pars[15] = int.Parse(Par16.SelectedValue);
        pars[16] = int.Parse(Par17.SelectedValue);
        pars[17] = int.Parse(Par18.SelectedValue);
        bool b = cb.CreateCourse(DescriptionTB.Text, pars);
    }
}