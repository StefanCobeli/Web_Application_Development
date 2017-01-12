using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
    protected String requestedName;
    protected void Page_Load(object sender, EventArgs e)
    {
        requestedName = Request.QueryString["Name"];

        Response.Write("We recived the search word: " + Request.QueryString["Name"]);
        foreach (RepeaterItem foundedUser in SearchResultsRepeater.Items)
        {
            ((HyperLink)foundedUser.FindControl("UserGasit")).NavigateUrl = "~/ProfilePage.aspx?Name=" + ((Label)foundedUser.FindControl("FoundedNick")).Text;
            HyperLink foundedName = (HyperLink)foundedUser.FindControl("UserGasit");
            foundedName.NavigateUrl = "~/ProfilePage.aspx?Name=" + ((Label)foundedUser.FindControl("FoundedNick")).Text;
            foundedName.Text = "blaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        }

    }

    protected void requestUsers()
    {
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        string search = "Select * From Utilizator Where Nick LIKE @Word OR Nume LIKE @Word OR Prenume LIKE @Word";
        conn.Open();
        SqlCommand searchQuery = new SqlCommand(search, conn);
        searchQuery.Parameters.AddWithValue("@Word", requestedName);
    }


}