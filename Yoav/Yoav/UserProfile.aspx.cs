using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace Yoav
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"] == null)
            {
                Response.Redirect("Errorpage.aspx");
            }
            if (Session["user"] != null)
            {
                if (Session["user"].ToString() == Request.QueryString["Username"])
                {
                    Add_link.Visible = true;
                    User_update.Visible = true;
                    YoutubeLink.Visible = true;
                }
            }
            User_Name.Text = Request.QueryString["Username"];
            if (!IsPostBack)
            {
                OleDbConnection con1 = new OleDbConnection();
                con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con1.Open();
                string sqlstring = @"SELECT FirstName, LastName FROM users_tbl WHERE Username = @usr";
                OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
                conSer.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
                OleDbDataReader Drdr = conSer.ExecuteReader();
                while (Drdr.Read())
                {
                    if (Drdr.HasRows)
                    {
                        First_Name.Text = Drdr.GetString(0);
                        Last_Name.Text = Drdr.GetString(1);
                        //implement youtube links
                    }
                }
                con1.Close();
            }
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Link, Link_order FROM links_tbl WHERE Username = @usr ORDER BY Link_order DESC";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            while (Drdr2.Read())
            {
                if (Drdr2.HasRows)
                {
                    //.
                }
            }
            con2.Close();

        }
        protected void Update_User(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("UpdateUser.aspx?Username={0}", Request.QueryString["Username"]));
        }
        protected void Add_Link(object sender, EventArgs e)
        {
            string link = YoutubeLink.Text;
            YoutubeData.
            YoutubeData.DataSource = link;
            YoutubeData.DataBind();
            YoutubeLink.Text = "";

        }
    }
}