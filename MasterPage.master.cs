using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (userIsLoggedin())
        {
            LoggedInUserName.Text = Membership.GetUser().UserName;
        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(SearchBox.Text))
        {
            return;
        }
        Response.Redirect("Search.aspx?Name=" + SearchBox.Text, true);
    }

    protected bool userIsLoggedin()
    {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    }
}
