using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_v2 : System.Web.UI.Page
{
    protected bool userIsLoggedin() {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;  
    }  
    protected void Page_Load(object sender, EventArgs e)
    {      
        if (userIsLoggedin())
        {
            string nume = Membership.GetUser().UserName;
            Response.Redirect("Default.aspx");
           
        }
        else
        {
            Response.Write("Anonim!!!");
        }
    }

}