using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    private const String sqlConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CheckLogin()) {
            Response.Redirect("Default.aspx", true);
        }
        Login1.UserName = "Stefanel";
        

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Stefan\\Desktop\\DAW\\Lab07Try\\App_Data\\Database.mdf;Integrated Security=True");
        
        string queryDeVerificare = "SELECT Parola, Prenume FROM Utilizator WHERE (Nume=@Nume)";
		// deschiderea conexiunii. Poate arunca Exceptie daca nu reuseste
		conn.Open();
		//crearea comenzi SQL
		SqlCommand verificare = new SqlCommand(queryDeVerificare, conn);
		//adaugarea parametrilor si definirea tipului lor
		verificare.Parameters.AddWithValue("@Nume", Login1.UserName);
		//scalar returneaza o singura valoare
		SqlDataReader reader = verificare.ExecuteReader();

        if (reader.Read()) {
            string password = (string)reader["Parola"];
            //DDLBrand.SelectedValue = reader["IdBrand"].ToString();
            password = password.Trim();
            if (Login1.Password == password)
            {
                
                Session["Utilizator"] = Login1.UserName;
                Session["Parola"] = Login1.Password;
                
                if (reader["Prenume"] == null){
                    Response.Redirect("FirstLogin.aspx");
                    conn.Close();
                    return;
                }
                conn.Close();
                Response.Redirect("ProfilePage.aspx");
            }
            else
            {
                //parola invalida
                Login1.FailureText = "Parola nu este valida!";
                conn.Close();
                return;
            }
            }
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