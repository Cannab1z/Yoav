using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;


namespace Yoav
{
    public partial class SearchUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"] == null || Request.QueryString["Username"].ToString() == "")
            {
                error_btn.Text = "You must pass in a username";
                return;
            }
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = "select FirstName, LastName, Username FROM users_tbl WHERE Username = @usr";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            OleDbDataReader Drdr = conSer.ExecuteReader();
            if (Drdr.HasRows)
            {
                DataListUsers.DataSource = Drdr;
                DataListUsers.DataBind();
            }
            else
            {
                error_btn.Text = "No such user was found";
            }
            
            con1.Close();
        }
        protected void Send_Profile(object sender, EventArgs e)
        {
            LinkButton hey = (LinkButton)sender;
            Response.Redirect("UserProfile?Username=" + hey.Text);
        }

    }
}