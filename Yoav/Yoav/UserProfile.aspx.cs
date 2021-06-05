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
        private System.Data.DataSet dataSet = new DataSet();
        private int count = 0;
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
                    Link_Edit.Visible = true;
                }
            }
            User_Name.Text = Request.QueryString["Username"];
            if (!Page.IsPostBack)
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
                Load_Images();
            }
            Load_Links();

        }
        protected void Load_Links()
        {
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Link, Link_order FROM links_tbl WHERE Username = @usr ORDER BY Link_order ASC";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            DataTable dt = new DataTable("youtube");
            DataColumn dc = new DataColumn();
            dc.ColumnName = "link";
            dt.Columns.Add(dc);
            dc = new DataColumn("count");
            dt.Columns.Add(dc);
            while (Drdr2.Read())
            {
                DataRow dr = dt.NewRow();
                dr["link"] = "https://www.youtube.com/embed/" + Drdr2.GetString(0);
                dr["count"] = int.Parse(Drdr2.GetString(1));
                count = int.Parse(Drdr2.GetString(1));
                dt.Rows.Add(dr);
            }
            dataSet.Tables.Add(dt);
            con2.Close();
            YoutubeData.DataSource = dt;
            YoutubeData.DataBind();
        }
        protected void Update_User(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("UpdateUser.aspx?Username={0}", Request.QueryString["Username"]));
        }
        protected void Add_Link(object sender, EventArgs e)
        {
            if (YoutubeLink.Text == "")
            {
                youtube_link_error.Text = "you must input a valid youtube link";
                return;
            }
            int found = 0;
            if (YoutubeLink.Text.IndexOf("?v=") > -1)
            {
                found = YoutubeLink.Text.IndexOf("?v=") + 3;
            }
            else if (YoutubeLink.Text.IndexOf("youtu.be/") > -1)
            {
                found = YoutubeLink.Text.IndexOf("youtu.be/") + 9;
            }
            else
            {
                //error message
                return;
            }
            string link = YoutubeLink.Text.Substring(found);
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = @"INSERT INTO links_tbl (Username ,Link, Link_Order) values (@usr,@link,@count)";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer.Parameters.AddWithValue("@link", link);
            conSer.Parameters.AddWithValue("@count", (count + 1).ToString());
            int Check = 0;
            Check = conSer.ExecuteNonQuery();
            con1.Close();
            YoutubeLink.Text = "";
            Response.Redirect(Request.RawUrl);
        }
        protected void Load_Images()
        {
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Link, Link_order FROM links_tbl WHERE Username = @usr ORDER BY Link_order ASC";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            DataTable dt = new DataTable("images");
            DataColumn dc = new DataColumn("link");
            dt.Columns.Add(dc);
            dc = new DataColumn("count");
            dt.Columns.Add(dc);
            while (Drdr2.Read())
            {
                DataRow dr = dt.NewRow();
                dr["link"] = "http://img.youtube.com/vi/" + Drdr2.GetString(0) + "/default.jpg";
                dr["count"] = int.Parse(Drdr2.GetString(1));
                dt.Rows.Add(dr);
            }
            dataSet.Tables.Add(dt);
            YoutubeThumbnail.DataSource = dt;
            YoutubeThumbnail.DataBind();
            con2.Close();
        }
        protected void Edit_Link(object sender, EventArgs e)
        {
            if (YoutubeThumbnail.Visible == false)
            {
                YoutubeThumbnail.Visible = true;
                YoutubeData.Visible = false;
            }
            else
            {
                YoutubeData.Visible = true;
                YoutubeThumbnail.Visible = false;
            }
        }
        protected void Button_Delete(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in YoutubeThumbnail.Items)
            {
                CheckBox chk = item.FindControl("CheckDelete") as CheckBox;
                if (chk.Checked)
                {
                    Image img = ((Image)item.FindControl("img"));
                    string url = img.ImageUrl;
                    int found = url.IndexOf("vi/") + 3;
                    int finish = url.IndexOf("/default.jpg");
                    int last = finish - found;
                    string link = url.Substring(found, last);
                    Delete_Url(link);

                }
            }
            Response.Redirect("UserProfile?Username=" + Session["user"]);
        }
        protected void Delete_Url(string url)
        {
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"Delete * FROM links_tbl WHERE Username = @usr AND Link = @link";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer2.Parameters.AddWithValue("@link", url);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            con2.Close();
        }
    }
}