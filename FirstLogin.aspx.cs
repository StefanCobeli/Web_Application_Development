using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FirstLogin : System.Web.UI.Page
{
    protected const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
    protected String userName;
    protected String firstName;
    protected String lastName;
    protected String isPublic;
    protected String profilePicLink;
    protected String coverPicLink;
    protected const String insertionQuery = "INSERT into Utilizator(Id_Utilizator, Nume, Prenume, Nick, ProfilPublic, Link_Poza_Profil, Link_Poza_Cover) values (@UserId, @LastName, @FirstName, @UserName, @Privacy, @ProfilePic, @CoverPic)";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!userIsLoggedin())
        {
            Response.Redirect("Login.aspx");
        }
        if (!userIsNew())
        {
            Response.Redirect("ProfilePage.aspx");
        }
        userName = Membership.GetUser().UserName;
        string pathToCreate = "~/Data/" + userName;
        if (!Directory.Exists(Server.MapPath(pathToCreate)))
        {
            Response.Write("Personal folder for " + userName + " has been created!" );
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
        }
        
    }

    protected void OnSubimt_Click(object sender, EventArgs e)
    {
        savePicture("Profile");
        savePicture("Cover");
        firstName = FirstName.Text;
        lastName = LastName.Text;
        isPublic = Privacy.SelectedItem.Text.Equals("Public") ? "True" : "False";
        executeInsertionQuery();
        Response.Redirect("ProfilePage.aspx");
    }

    protected void saveCoverPicture()
    {
    }
    protected void saveProfilePicture()
    {

    }
    protected void executeInsertionQuery()
    {
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        conn.Open();
        SqlCommand insertCommand = new SqlCommand(insertionQuery, conn);
        insertCommand.Parameters.AddWithValue("@UserId", Membership.GetUser().ProviderUserKey.ToString());
        insertCommand.Parameters.AddWithValue("@LastName", lastName);
        insertCommand.Parameters.AddWithValue("@FirstName", firstName);
        insertCommand.Parameters.AddWithValue("@UserName", userName);
        insertCommand.Parameters.AddWithValue("@Privacy", isPublic);
        insertCommand.Parameters.AddWithValue("@ProfilePic", profilePicLink);
        insertCommand.Parameters.AddWithValue("@CoverPic", coverPicLink);
        insertCommand.ExecuteNonQuery();
        conn.Close();
    }

    protected void savePicture(string type)
    {
        string fileName = type.Equals("Profile") ? this.ProfilePictureUpload.FileName : CoverPictureUpload.FileName;
        String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        string fileType = Path.GetExtension(fileName);
         if (type.Equals("Profile"))
        {
            ProfilePictureUpload.PostedFile.SaveAs(Server.MapPath("~/Data/") + userName + "/" + type + "_" + timeStamp + fileType);
            profilePicLink = "~/Data/" + userName + "/" + type + "_" + timeStamp + fileType;
        } 
        else
        {
            CoverPictureUpload.PostedFile.SaveAs(Server.MapPath("~/Data/") + userName + "/" + type + "_" + timeStamp + fileType);
            coverPicLink = "~/Data/" + userName + "/" + type + "_" + timeStamp + fileType;
     
        }
    }

    protected bool userIsLoggedin()
    {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
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
   
}