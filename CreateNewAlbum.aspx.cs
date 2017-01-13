using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewAlbum : System.Web.UI.Page
{
    protected const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
    protected String userId;
    protected const String insertAlbumQuerry = "INSERT into Album(Nume_album, Id_Utilizator) values (@AlbumName, @UserId)";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!userIsLoggedin())
        {
            Response.Redirect("Login.aspx",true);
        }
        userId = Membership.GetUser().ProviderUserKey.ToString();
    }

    protected bool userIsLoggedin()
    {
        return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    }

    protected void CreateAlbumButton_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True");
        conn.Open();
        SqlCommand insertAlbumCommand = new SqlCommand(insertAlbumQuerry, conn);
        insertAlbumCommand.Parameters.AddWithValue("@AlbumName", AlbumName.Text);
        insertAlbumCommand.Parameters.AddWithValue("@UserId", userId);
        insertAlbumCommand.ExecuteNonQuery();
        Response.Redirect("Album.aspx?AlbumName=" + AlbumName.Text, true);
    }
}