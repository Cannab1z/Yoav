using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class InsertUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddUser_Click(object sender, EventArgs e)
    {
        /*OleDbConnection con1 = new OleDbConnection();
        con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Server.MapPath("") + "\\MyDataBase.accdb";
        con1.Open();
        string sqlstring = "insert into MyUsers (myfirstname,myoccupation) values ('" + FirstName.Text + "','"+ Category.SelectedValue +"')";
        OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
        int Check = 0;
        Check=conSer.ExecuteNonQuery();
        Response.Write("you entered " + Check + " users");
        con1.Close();*/
    }
}