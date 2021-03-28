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
            error.Text = Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
        }
        protected void AddUser_Click(object sender, EventArgs e)
        {
            string[] date = new string[3];
            date = datepicker.Text.Split('-');
            string full_date = date[2] + "." + date[1] + "." + date[0];
            string first_name = FirstName.Text;
            string last_name = LastName.Text;
            string username = Username.Text;
            string password = Passowrd.Text;
            string email = Email.Text;
            //error.Text = Server.MapPath(".") + "\\Yoav_DB.accdb";
            error.Text = "INSERT INTO users_tbl (FirstName,LastName,Email,UserName,Password,Birthdate) values ('" + FirstName.Text + "','"+ LastName.Text +"','" + Email.Text +"','"+ Username.Text +"','"+Passowrd.Text+"','"+full_date+ "')";
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
            Response.Write("You entered: " + Check);
            con1.Close();
        }
    }
}