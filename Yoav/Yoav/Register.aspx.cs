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
            error.Text = Request.PhysicalApplicationPath + "\Yoav_DB.accdb";
        }
        protected void AddUser_Click(object sender, EventArgs e)
        {
            string[] hey = new string[3];
            hey = datepicker.Text.Split('-');
            string year = hey[0];
            string month = hey[1];
            string day = hey[2];
            /*error.Text = year + " " + month + " " + day;
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Server.MapPath(".") + "\\Yoav_DB.accdb";
            con1.Open();
            //string sqlstring = "insert into MyUsers (myfirstname,myoccupation) values ('" + FirstName.Text + "','"+ Category.SelectedValue +"')";
            //OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            int Check = 0;
            //Check=conSer.ExecuteNonQuery();
            //Response.Write("you entered " + Check + " users");
            con1.Close();*/

        }
    }
}