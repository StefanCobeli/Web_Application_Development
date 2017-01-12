using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilPrivat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchedName.Text = Request.QueryString["Name"];
        if (userIsLoggedin())
        {
            FriendRequestButton.Visible = true;
        }
    }
    protected void FriendRequestButton_Click(object sender, EventArgs e)
    {
        Response.Write("Trimit cerere de prietenie curand. ");
    }

    protected bool userIsLoggedin()
    {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    }
}