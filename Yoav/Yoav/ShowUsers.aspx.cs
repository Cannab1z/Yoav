using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace Yoav
{
    public partial class ShowUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Show_users(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = "select FirstName, LastName, Username, Email, Birthdate FROM users_tbl";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            OleDbDataReader Drdr = conSer.ExecuteReader();
            DataListUsers.DataSource = Drdr;
            DataListUsers.DataBind();
            con1.Close();
        }
        /*protected void Delete_user(object sender, EventArgs e)
        {
        }*/
        protected void DataListUsers_ItemCommand(object source, DataListCommandEventArgs e)
        {
            DataListUsers.SelectedIndex = e.Item.ItemIndex;
            Delete_help.Text = ((Label)DataListUsers.SelectedItem.FindControl("Username")).Text;
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = @"Delete * FROM users_tbl WHERE Username = @usr";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@usr", Delete_help.Text);
            OleDbDataReader Drdr = conSer.ExecuteReader();
            con1.Close();
            Response.Redirect("Register.aspx");
        }
    }
}