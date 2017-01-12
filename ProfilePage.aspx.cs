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
    protected String loggedUserName;
    protected void Page_Load(object sender, EventArgs e)
    {
        loggedUserName = Request.QueryString["Name"];
        String searchedUser = Request.QueryString["Name"];
        if (!userIsLoggedin() && String.IsNullOrEmpty(searchedUser))
        {
            Response.Redirect("Login.aspx");
        }
        if (String.IsNullOrEmpty(searchedUser) && userIsNew())
        {
            Response.Redirect("FirstLogin.aspx");
        }

        populateInformation();

    }

    protected void populateInformation()
    {
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        string userInfo = "Select TOP 1 * From Utilizator Where Nick = @Name";
        conn.Open();
        SqlCommand infoQuery = new SqlCommand(userInfo, conn);
        infoQuery.Parameters.AddWithValue("@Name", loggedUserName);
        SqlDataReader reader = infoQuery.ExecuteReader();
        if (reader.Read())
        {
            if(!(bool)reader["ProfilPublic"])
            {
                Response.Redirect("ProfilPrivat.aspx?Name=" + reader["Nume"] + "  " + reader["Prenume"] + " (" + loggedUserName + ")");
            }
            ProfileName.Text = reader["Nume"].ToString() + reader["Prenume"] + "(" + reader["Nick"] + ")";   
            ProfileImg.ImageUrl = (string)reader["Link_Poza_Profil"];
            CoverImg.ImageUrl = (string)reader["Link_Poza_Cover"];
            Response.Write("Pagina aparține utilizatorului " + reader["Nume"] + "  " + reader["Prenume"] + " Numit și " + reader["Nick"] +". El are intimitatea " + reader["ProfilPublic"]);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }

    protected bool userIsNew()
    {
        loggedUserName = Membership.GetUser().UserName;
        string userInUtilizatoriQuery = "Select TOP 1 Nick From Utilizator Where Nick = @Name";
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand verificare = new SqlCommand(userInUtilizatoriQuery, conn);
        verificare.Parameters.AddWithValue("@Name", loggedUserName);
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