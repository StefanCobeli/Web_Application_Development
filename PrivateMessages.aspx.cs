using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Messages : System.Web.UI.Page
{
    protected const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
    protected String loggedUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (userIsLoggedin())
        {
            SqlFriendsDataSource.SelectParameters.Add("Name", Membership.GetUser().UserName);
            //Session["Name"] = Membership.GetUser().UserName;
        }
    }

    protected bool userIsLoggedin()
    {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    }

}