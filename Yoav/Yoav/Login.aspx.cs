using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace Yoav
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            label_error.Text = "";
        }
        protected void Check_login(object sender, EventArgs e)
        {
            if (Username.Text == "idankidron" && user_pass.Text == "idankidron")
            {
                Session["admin"] = "true";
                Session["user"] = "idankidron";
                Response.Redirect("ShowUsers.aspx");
                return;
            }
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = @"SELECT UserName, user_Password FROM users_tbl WHERE UserName = @usr AND user_Password = @pass";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@usr", Username.Text);
            conSer.Parameters.AddWithValue("@pass", user_pass.Text);
            OleDbDataReader Drdr = conSer.ExecuteReader();
            Drdr.Read();
            if (Drdr.HasRows)
            {
                Session["user"] = Username.Text;
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                label_error.Text = "Username and/or password are incorrect";
            }
            con1.Close();
        }
    }
}