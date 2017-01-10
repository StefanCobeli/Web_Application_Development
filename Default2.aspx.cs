using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool val1 = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
       
        if (val1)
        {
            string nume = Membership.GetUser().UserName;
            Response.Write("Autentificattt este " + nume);

        }
        else {
            Response.Write("Anonim!!!");
        }


    }
}