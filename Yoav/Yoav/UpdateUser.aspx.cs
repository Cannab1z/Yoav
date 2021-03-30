using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace Yoav
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Username.Text = Request.QueryString["Username"];
            if (!IsPostBack)
            {
                Email.Text = Request.QueryString["Email"];
                OleDbConnection con1 = new OleDbConnection();
                con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con1.Open();
                string sqlstring = @"SELECT FirstName, LastName FROM users_tbl WHERE UserName = @usr";
                OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
                conSer.Parameters.AddWithValue("@usr", Username.Text);
                OleDbDataReader Drdr = conSer.ExecuteReader();
                while (Drdr.Read())
                {
                    if (Drdr.HasRows)
                    {
                        Header.Text = "Welcome " + Drdr.GetString(0) + " " + Drdr.GetString(1);
                    }
                }
                con1.Close();
            }
                
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            if (User_pass.Text == repeat_user_pass.Text)
            {
                OleDbConnection con1 = new OleDbConnection();
                con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con1.Open();
                string sqlstring = "UPDATE users_tbl SET user_Password='" + User_pass.Text + "' , Email='" + Email.Text + "' WHERE UserName='" + Username.Text + "'";
                OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
                int Check = 0;
                Check = conSer.ExecuteNonQuery();
                con1.Close();
                Response.Redirect("ShowUsers.aspx");
            }
            else
            {
                error_label.Text = "The passwords do not match";
            }
            
        }
    }
}