using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace Yoav
{
    public partial class UserProfile : System.Web.UI.Page
    {
        public int count = 0;
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
                    }
                }
                con1.Close();
            }
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Link, Link_order FROM links_tbl WHERE Username = @usr ORDER BY Link_order ASC";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            DataTable dt = new DataTable("table");
            DataColumn dc = new DataColumn();
            dc.ColumnName = "link";
            dt.Columns.Add(dc);
            while (Drdr2.Read())
            {
                DataRow dr = dt.NewRow();
                dr["link"] = "https://www.youtube.com/embed/" + Drdr2.GetString(0);
                count = int.Parse(Drdr2.GetString(1));
                dt.Rows.Add(dr);
            }
            YoutubeData.DataSource = dt;
            YoutubeData.DataBind();
            con2.Close();
            hey.Text = count.ToString();
        }
        protected void Update_User(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("UpdateUser.aspx?Username={0}", Request.QueryString["Username"]));
        }
        protected void Add_Link(object sender, EventArgs e)
        {
            /*DataTable dt = new DataTable("table");
            DataColumn dc = new DataColumn();
            dc.ColumnName = "link";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            int found = YoutubeLink.Text.IndexOf("?v=");
            string link = YoutubeLink.Text.Substring(found + 3);
            dr["link"] = "https://www.youtube.com/embed/" + link;
            hey.Text = link;
            dt.Rows.Add(dr);
            YoutubeData.DataSource = dt;*/
            hey.Text = count.ToString();
            count++;
            int found = YoutubeLink.Text.IndexOf("?v=");
            string link = YoutubeLink.Text.Substring(found + 3);
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = @"INSERT INTO links_tbl (Username ,Link, Link_Order) values (@usr,@link,@count)";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer.Parameters.AddWithValue("@link", link);
            conSer.Parameters.AddWithValue("@count", count.ToString());
            int Check = 0;
            Check = conSer.ExecuteNonQuery();
            con1.Close();
            YoutubeLink.Text = "";

        }
    }
}