using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    private const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CheckLogin()) {
            Response.Redirect("ProfilePage.aspx", true);
        }

    }

    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", true);        
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Response.Write(CreateUserWizard1.UserName + " has the email " 
            + CreateUserWizard1.Email + "!\n");
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True");
        
        string insertUserQuery = "insert into Utilizator(Nume, Parola, Email, ProfilPublic) values (@Nume, @Parola, @Email, 'True')";
        SqlCommand insertCommand = new SqlCommand(insertUserQuery, conn);
        conn.Open();
        
        insertCommand.Parameters.AddWithValue("@Nume", CreateUserWizard1.UserName);
        insertCommand.Parameters.AddWithValue("@Parola", CreateUserWizard1.Password);
        insertCommand.Parameters.AddWithValue("@Email", CreateUserWizard1.Email);
        
        insertCommand.ExecuteNonQuery();
        conn.Close();

    }
    private bool CheckLogin()
    {
        //daca nu avem user trebuie sa ne logam
        // poate a expirat sesiunea sau poate cineva vrea sa intre prin URL
        if (Session["Utilizator"] == null || string.IsNullOrEmpty(Session["Utilizator"].ToString()))
            return false;
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        string findUserQuery = "SELECT Parola FROM Utilizator WHERE (Nume=@Nume)";
        conn.Open();

        SqlCommand cmd = new SqlCommand(findUserQuery, conn);
        //adaugarea parametrilor si definirea tipului lor
        cmd.Parameters.Add(new SqlParameter("@Nume", TypeCode.String));
        cmd.Parameters["@Nume"].Value = Session["Utilizator"].ToString();
        
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            string queryPass = (string)reader[0];
            queryPass = queryPass.Trim();
            if (Session["Parola"].ToString() == queryPass)
            {
                conn.Close();
                return true;
            }
        }
        conn.Close();
        return false;
    }
}