using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilePage : System.Web.UI.Page
{
    protected const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!userIsLoggedin())
        {
            Response.Redirect("Login.aspx");
        }
        if (userIsNew())
        {
            Response.Redirect("FirstLogin.aspx");
        }
    }

    protected bool userIsNew()
    {
        string userName = Membership.GetUser().UserName;
        string userInUtilizatoriQuery = "Select TOP 1 Nick From Utilizator Where Nick = @Name";
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True");
        conn.Open();
        SqlCommand verificare = new SqlCommand(userInUtilizatoriQuery, conn);
        verificare.Parameters.AddWithValue("@Name", userName);
        SqlDataReader reader = verificare.ExecuteReader();

        if (reader.Read())
        {
            return false;
        } 

        return true;
    } 

    protected bool userIsLoggedin()
    {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    }  
}