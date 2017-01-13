using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilPrivat : System.Web.UI.Page
{
    protected const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
    protected String loggedUser;
    protected String searchedUser;
    protected String loggedFirstName;
    protected String loggedSecondName;
    protected String searchedFirstName;
    protected String searchedSecondName;

    protected void Page_Load(object sender, EventArgs e)
    {
        searchedUser = Request.QueryString["Nick"];
        searchedFirstName = Request.QueryString["FName"];
        searchedSecondName = Request.QueryString["SName"];
        SearchedName.Text = searchedFirstName + " " + searchedSecondName + " (" + searchedUser + ")";
        if (userIsLoggedin())
        {
            loggedUser = Membership.GetUser().UserName;
            FriendRequestButton.Visible = true;
        }
    }
    protected void FriendRequestButton_Click(object sender, EventArgs e)
    {
        Response.Write("Trimit cerere de prietenie curand. ");
        if (requestAllreadySent()) 
        {
            Response.Write("Cererea de prietenie a fost înregistrată deja. Te rugăm să aștepți confirmarea.");
        }
        else
        {
            String friendRequest = "INSERT INTO Prieteni (Nick_Cerut, Nume_Cerut, Prenume_Cerut, Acceptat, Nick_Primit, Nume_Primit, Prenume_Primit) values (@LoggedNick, @LoggedSName, @LoggedFName, @Accepted, @SearchedNick, @SearchedSName, @SearchedFName)";
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            SqlCommand friendRequestCommand = new SqlCommand(friendRequest, conn);
            findLoggedInfo();
            friendRequestCommand.Parameters.AddWithValue("@LoggedNick", loggedUser);
            friendRequestCommand.Parameters.AddWithValue("@LoggedFName", loggedFirstName);
            friendRequestCommand.Parameters.AddWithValue("@LoggedSName", loggedSecondName);
            friendRequestCommand.Parameters.AddWithValue("@Accepted", "False");
            friendRequestCommand.Parameters.AddWithValue("@SearchedNick", searchedUser);
            friendRequestCommand.Parameters.AddWithValue("@SearchedFName", searchedFirstName);
            friendRequestCommand.Parameters.AddWithValue("@SearchedSName", searchedSecondName);
            friendRequestCommand.ExecuteNonQuery();
            conn.Close();
        }
    }

    protected bool userIsLoggedin()
    {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    }


    protected bool requestAllreadySent()
    {
        String findRequest = "Select TOP 1 * From Prieteni WHERE (Nick_Cerut = @Logged AND Nick_Primit = @Searched) OR (Nick_Cerut = @Searched AND Nick_Primit = @Logged )";
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand findRequestCommand = new SqlCommand(findRequest, conn);
        findRequestCommand.Parameters.AddWithValue("@Logged", loggedUser);
        findRequestCommand.Parameters.AddWithValue("@Searched", searchedUser);
        SqlDataReader reader = findRequestCommand.ExecuteReader();
        if (reader.Read())
        {
            conn.Close();
            return true;
        }
        conn.Close();
        return false;
    }

    protected void findLoggedInfo()
    {
        String findInfo = "SELECT Nume, Prenume FROM Utilizator WHERE Nick=@Name";
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand findInfoCommand = new SqlCommand(findInfo, conn);
        findInfoCommand.Parameters.AddWithValue("@Name", loggedUser);
        SqlDataReader reader = findInfoCommand.ExecuteReader();
        if (reader.Read())
        {
            loggedSecondName = reader[0].ToString();
            loggedFirstName = reader[1].ToString();
        }
        conn.Close();
    }


}