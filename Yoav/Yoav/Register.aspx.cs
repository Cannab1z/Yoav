using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace Yoav
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void AddUser_Click(object sender, EventArgs e)
        {
            string[] date = datepicker.Text.Split('-');
            date = datepicker.Text.Split('-');
            string full_date = date[2] + "." + date[1] + "." + date[0];
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = "+ Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = @"INSERT INTO users_tbl (FirstName, LastName, Email, UserName, user_Password, Birthdate) values (@first,@last,@email,@user,@pass,@birth)";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@first", FirstName.Text);
            conSer.Parameters.AddWithValue("@last", LastName.Text);
            conSer.Parameters.AddWithValue("@email", Email.Text);
            conSer.Parameters.AddWithValue("@user", Username.Text);
            conSer.Parameters.AddWithValue("@pass", Passowrd.Text);
            conSer.Parameters.AddWithValue("@birth", full_date);
            int Check = 0;
            Check = conSer.ExecuteNonQuery();
            con1.Close();
            Response.Redirect("ShowUsers.aspx");
        }
    }
}