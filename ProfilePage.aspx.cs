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
    protected String loggedFirstName;
    protected String loggedSecondName;
    protected String searchedUser;
    protected String searchedFirstName;
    protected String searchedSecondName;
    protected bool ownPage;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["FName"]))
        {
            acceptFriendRequest();
        }
        if (!userIsLoggedin())
        {
            searchedUser = Request.QueryString["Name"];
            if (String.IsNullOrEmpty(searchedUser))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                loggedUserName = Request.QueryString["Name"];
            }
        }
        else
        {
            loggedUserName = Membership.GetUser().UserName;
        }
        if (String.IsNullOrEmpty(searchedUser) && userIsNew())
        {
            Response.Redirect("FirstLogin.aspx");
        }
        searchedUser = String.IsNullOrEmpty(Request.QueryString["Name"]) ? loggedUserName : Request.QueryString["Name"];
        ownPage = loggedUserName.Equals(searchedUser);
        populateInformation();

    }

    protected void populateInformation()
    {
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        string userInfo = "Select TOP 1 * From Utilizator Where Nick = @Name";
        conn.Open();
        SqlCommand infoQuery = new SqlCommand(userInfo, conn);
        infoQuery.Parameters.AddWithValue("@Name", searchedUser);
        SqlDataReader reader = infoQuery.ExecuteReader();
        if (reader.Read())
        {
            if (!(bool)reader["ProfilPublic"] && !ownPage && !usersAreFriends())
            {
                Response.Redirect("ProfilPrivat.aspx?SName=" + reader["Nume"] + "&FName=" + reader["Prenume"] + "&Nick=" + searchedUser);
            }
            if(userIsLoggedin() && !loggedUserName.Equals(searchedUser))
            {
                FriendshipRequestButton.Visible = true;
                searchedFirstName = reader["Nume"].ToString();
                searchedSecondName = reader["Prenume"].ToString();
            }
            displayFriendRequests();
            Session["Nick"] = reader["Nick"];
            ProfileName.Text = reader["Nume"].ToString() + reader["Prenume"] + "(" + reader["Nick"] + ")";   
            ProfileImg.ImageUrl = (string)reader["Link_Poza_Profil"];
            CoverImg.ImageUrl = (string)reader["Link_Poza_Cover"];
            Response.Write("Pagina aparține utilizatorului " + reader["Nume"] + "  " + reader["Prenume"] + " Numit și " + reader["Nick"] +". El are intimitatea " + reader["ProfilPublic"]);
            conn.Close();
        }
        else
        {
            conn.Close();
            Response.Redirect("Default.aspx");
        }

    }

    protected bool userIsNew()
    {
        string userInUtilizatoriQuery = "Select TOP 1 Nick From Utilizator Where Nick = @Name";
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand verificare = new SqlCommand(userInUtilizatoriQuery, conn);
        verificare.Parameters.AddWithValue("@Name", loggedUserName);
        SqlDataReader reader = verificare.ExecuteReader();
        if (reader.Read())
        {
            conn.Close();
            return false;
        }
        conn.Close();
        return true;
    } 

    protected bool userIsLoggedin()
    {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    }

    protected void FriendshipRequestButton_Click(object sender, EventArgs e)
    {
        if (requestAllreadySent())
        {
            Response.Write("Cererea de prietenie a fost deja trimisă!");
            return;
        }
        String friendRequest = "INSERT INTO Prieteni (Nick_Cerut, Nume_Cerut, Prenume_Cerut, Acceptat, Nick_Primit, Nume_Primit, Prenume_Primit) values (@LoggedNick, @LoggedSName, @LoggedFName, @Accepted, @SearchedNick, @SearchedSName, @SearchedFName)";
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand friendRequestCommand = new SqlCommand(friendRequest, conn);
        findLoggedInfo();
        friendRequestCommand.Parameters.AddWithValue("@LoggedNick", loggedUserName);
        friendRequestCommand.Parameters.AddWithValue("@LoggedFName", loggedFirstName);
        friendRequestCommand.Parameters.AddWithValue("@LoggedSName", loggedSecondName);
        friendRequestCommand.Parameters.AddWithValue("@Accepted", "False");
        friendRequestCommand.Parameters.AddWithValue("@SearchedNick", searchedUser);
        friendRequestCommand.Parameters.AddWithValue("@SearchedFName", searchedFirstName);
        friendRequestCommand.Parameters.AddWithValue("@SearchedSName", searchedSecondName);
        friendRequestCommand.ExecuteNonQuery();
        conn.Close();
    }

    protected void findLoggedInfo()
    {
        String findInfo = "SELECT Nume, Prenume FROM Utilizator WHERE Nick=@Name";
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand findInfoCommand = new SqlCommand(findInfo, conn);
        findInfoCommand.Parameters.AddWithValue("@Name", loggedUserName);
        SqlDataReader reader = findInfoCommand.ExecuteReader();
        if (reader.Read())
        {
            loggedSecondName = reader[0].ToString();
            loggedFirstName = reader[1].ToString();
        }
        conn.Close();
    }

    protected bool requestAllreadySent()
    {
        String findRequest = "Select TOP 1 * From Prieteni WHERE (Nick_Cerut = @Logged AND Nick_Primit = @Searched) OR (Nick_Cerut = @Searched AND Nick_Primit = @Logged )";
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand findRequestCommand = new SqlCommand(findRequest, conn);
        findRequestCommand.Parameters.AddWithValue("@Logged", loggedUserName);
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

    protected bool usersAreFriends()
    {
        String findRequest = "Select TOP 1 * From Prieteni WHERE (Nick_Cerut = @Logged AND Nick_Primit = @Searched And Acceptat = 'True') OR (Nick_Cerut = @Searched AND Nick_Primit = @Logged AND Acceptat = 'True')";
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand findRequestCommand = new SqlCommand(findRequest, conn);
        findRequestCommand.Parameters.AddWithValue("@Logged", loggedUserName);
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

    protected void displayFriendRequests()
    {
        if (userIsLoggedin() && loggedUserName.Equals(searchedUser))
        {
            FriendRequests.Style.Value = "visibility:visible";
        }
    }

    protected void acceptFriendRequest() 
    { 
        //PostBackUrl='<%# "~/ProfilePage.aspx?Accepted=" + Eval("Nick_Cerut") 
        //+ "&SName=" + Eval("Nume_Cerut") + "&FName=" + Eval("Prenume_Cerut")%>' 
        Response.Write("Friendship will be accepted!!!!!!!!!!!!!!!!!!!!!!");
        loggedUserName = Membership.GetUser().UserName;
        //UPDATE mytable SET column1 = value1, column2 = value2 WHERE key_value = some_value;
        //String acceptFriendship = "UPDATE Prieteni SET Acceptat = 'True' WHERE Nick_Primit = '" + loggedUserName + "' AND Nick_Cerut = '" + Request.QueryString["Accepted"] + "'";
        String acceptFriendship = "UPDATE Prieteni SET Acceptat = 'True' WHERE Nick_Primit = @Logged AND Nick_Cerut = @Accepted";
        
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand acceptFriendCommand = new SqlCommand(acceptFriendship, conn);
        acceptFriendCommand.Parameters.AddWithValue("@Logged", loggedUserName);
        acceptFriendCommand.Parameters.AddWithValue("@Accepted", Request.QueryString["Accepted"]);
        acceptFriendCommand.ExecuteNonQuery();
        conn.Close();
    }
}