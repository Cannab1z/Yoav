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
            if (Session["admin"] == null)
            {
                Show.Visible = false;
                Label_help.Text = "You dont have permission to this page, please connect as an admin";
            }
            else
            {
                Show.Visible = true;
            }
        }
        protected void Show_users(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = "select FirstName, LastName, Username, Email, user_Password, Birthdate FROM users_tbl";
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
            if (e.CommandName == "Delete_command")
            {
                DataListUsers.SelectedIndex = e.Item.ItemIndex;
                Label_help.Text = ((Label)DataListUsers.SelectedItem.FindControl("Username")).Text;
                OleDbConnection con1 = new OleDbConnection();
                con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con1.Open();
                string sqlstring = @"Delete * FROM users_tbl WHERE Username = @usr";
                OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
                conSer.Parameters.AddWithValue("@usr", Label_help.Text);
                OleDbDataReader Drdr = conSer.ExecuteReader();
                con1.Close();
                Response.Redirect("Register.aspx");
            }
            else if (e.CommandName == "Update_command")
            {
                DataListUsers.SelectedIndex = e.Item.ItemIndex;
                Label_help.Text = ((Label)DataListUsers.SelectedItem.FindControl("Username")).Text;
                Response.Redirect(String.Format("UpdateUser.aspx?Username={0}", Label_help.Text));
            }
            
            
        }

    }
}