using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.Net;

namespace Yoav
{
    public partial class UserProfile : System.Web.UI.Page
    {
        [System.Web.Script.Services.ScriptService]
        public class ImageDTO
        {
            public string id { get; set; }
            public int order { get; set; }
        }
        private localhost.Links order = new localhost.Links();
        private System.Data.DataSet dataSet = new DataSet();
        private int count = 0;
        public static string query { get; set; }
        public static string current1 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = "";
            query = Request.QueryString["Username"];
            if (Request.QueryString["Username"] == null)
            {
                Response.Redirect("Errorpage.aspx");
            }
            if (Request.QueryString["playlist"] == null)
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                localhost.Links item = new localhost.Links();
                Current.Text = "1";
                PL_name.Text = item.GetPlaylistName(query, int.Parse(Current.Text));
                PL_likes.Text = item.GetLikes(query, int.Parse(Current.Text)).ToString();
            }
            else if (int.Parse(Request.QueryString["playlist"].ToString()) > 0 && int.Parse(Request.QueryString["playlist"].ToString()) < 100)
            {

                Current.Text = Request.QueryString["playlist"].ToString();
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                localhost.Links item = new localhost.Links();
                PL_name.Text = item.GetPlaylistName(query, int.Parse(Current.Text));
                PL_likes.Text = item.GetLikes(query, int.Parse(Current.Text)).ToString();
            }
            else
            {
                Response.Redirect("Errorpage.aspx");
            }
            if (Session["user"] != null)
            {
                Copy_playlist.Visible = true;
                if (Session["user"].ToString() == Request.QueryString["Username"].ToString() || Session["Admin"] == "true")
                {

                    Copy_playlist.Visible = false;
                    Like.Visible = false;
                    Add_link.Visible = true;
                    User_update.Visible = true;
                    YoutubeLink.Visible = true;
                    Link_Edit.Visible = true;
                    Edit_Delete.Visible = true;
                    Add_playlist.Visible = true;
                    Delete_playlist.Visible = true;
                    Edit_PL.Visible = true;

                    if (Session["Admin"] == "true")
                    {
                        Copy_playlist.Visible = true;
                        Like.Visible = true;
                        Add_playlist.Visible = false;
                        if (Session["user"].ToString() == Request.QueryString["Username"].ToString())
                        {
                            Copy_playlist.Visible = false;
                            Like.Visible = false;
                            Add_playlist.Visible = true;
                        }
                    }
                }
            }
            current1 = Current.Text;
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
                Load_Playlists();
            }
            Load_Links();

        }
        protected void Checkbox_Visible(object sender, EventArgs e)
        {
            YoutubeThumbnail.Visible = true;
            YoutubeData.Visible = false;
            foreach (RepeaterItem item in YoutubeThumbnail.Items)
            {
                CheckBox checkbox = (CheckBox)item.FindControl("CheckDelete");
                checkbox.Visible = true;
            }
            delete_btn.Visible = true;
        }
        protected void Load_Playlists()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            localhost.Links item = new localhost.Links();
            int num_of_playlists = item.GetPlaylistNumber(Request.QueryString["Username"].ToString());
            DataTable dt = new DataTable("playlists");
            DataColumn dc = new DataColumn("number");
            dt.Columns.Add(dc);
            for (int i = 0; i < num_of_playlists; i++)
            {
                DataRow dr = dt.NewRow();
                dr["number"] = i + 1;
                dt.Rows.Add(dr);
            }
            Playlist_lists.DataSource = dt;
            Playlist_lists.DataBind();

        }
        protected void Playlist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Click")
            {
                Playlist_lists.SelectedIndex = e.Item.ItemIndex;
                string selected = ((Button)Playlist_lists.SelectedItem.FindControl("number")).Text;
                Response.Redirect("UserProfile.aspx?Username=" + Request.QueryString["Username"] + "&playlist=" + selected);
            }
        }
        protected void Load_Links()
        {
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Link, Link_order FROM links_tbl WHERE Username = @usr AND List_number = @num ORDER BY Link_order ASC";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer2.Parameters.AddWithValue("@num", Current.Text);
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
                dr["count"] = Drdr2.GetValue(1);
                count = int.Parse(Drdr2.GetValue(1).ToString());
                dt.Rows.Add(dr);
            }
            if (!dataSet.Tables.Contains("youtube"))
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
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            localhost.Links full_link = new localhost.Links();
            string link = full_link.GetYoutubeId(YoutubeLink.Text).ToString();
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            string sqlstring = @"INSERT INTO links_tbl (Username ,Link, Link_Order, List_number) values (@usr,@link,@count,@num)";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer.Parameters.AddWithValue("@link", link);
            conSer.Parameters.AddWithValue("@count", (count + 1));
            conSer.Parameters.AddWithValue("@num", Current.Text);
            int Check = 0;
            Check = conSer.ExecuteNonQuery();
            con1.Close();
            YoutubeLink.Text = "";
            Response.Redirect(Request.RawUrl);
        }
        protected void Add_playlist_click(object sender, EventArgs e)
        {
            Response.Redirect("new_playlist.aspx");
        }
        protected void Copy_PL(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            localhost.Links item = new localhost.Links();
            int num = item.GetPlaylistNumber(Session["user"].ToString());
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT * FROM links_tbl WHERE Username = @usr AND List_number = @num";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer2.Parameters.AddWithValue("@num", Current.Text);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            while (Drdr2.Read())
            {
                OleDbConnection con1 = new OleDbConnection();
                con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con1.Open();
                string sqlstring = @"INSERT INTO links_tbl (Username, Link, Link_order, List_number) values (@usr,@link,@order,@num)";
                OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
                conSer.Parameters.AddWithValue("@usr", Session["user"]);
                conSer.Parameters.AddWithValue("@link", Drdr2["Link"]);
                conSer.Parameters.AddWithValue("@order", Drdr2["Link_order"]);
                conSer.Parameters.AddWithValue("@num", num + 1);
                int Check = 0;
                Check = conSer.ExecuteNonQuery();
                con1.Close();
            }
            con2.Close();
            string name = item.GetPlaylistName(Request.QueryString["Username"], int.Parse(Current.Text));
            item.AddPlaylist(Session["user"].ToString(), name);
        }
        protected void Edit_Playlists(object sender, EventArgs e)
        {
            Response.Redirect("Edit_playlists?Username=" + Request.QueryString["Username"]);
        }
        protected void Delete_PL(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            localhost.Links item = new localhost.Links();
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"Delete * FROM links_tbl WHERE Username = @usr AND List_number = @num";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer2.Parameters.AddWithValue("@num", Current.Text);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            con2.Close();
            //--------------------------
            OleDbConnection con4 = new OleDbConnection();
            con4.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con4.Open();
            string sqlstring4 = @"SELECT List_number FROM links_tbl WHERE Username = @usr";
            OleDbCommand conSer4 = new OleDbCommand(sqlstring4, con4);
            conSer4.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            OleDbDataReader Drdr4 = conSer4.ExecuteReader();
            DataTable dt = new DataTable("temp");
            dt.Load(Drdr4);

            foreach (DataRow dr in dt.Rows)
            {
                if (int.Parse(dr["List_number"].ToString()) > int.Parse(Current.Text))
                {
                    OleDbConnection con3 = new OleDbConnection();
                    con3.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                    con3.Open();
                    string sqlstring3 = @"UPDATE links_tbl SET List_number = @num WHERE Username = @usr AND List_number = @num2";
                    using (OleDbCommand conSer3 = new OleDbCommand(sqlstring3, con3))
                    {
                        conSer3.Parameters.AddWithValue("@num", (int.Parse(dr["List_number"].ToString()) - 1).ToString());
                        conSer3.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
                        conSer3.Parameters.AddWithValue("@num", dr["List_number"].ToString());
                        int Check = 0;
                        Check = conSer3.ExecuteNonQuery();

                    }
                    con3.Close();
                }
            }
            con4.Close();
            item.DeletePlaylist(Request.QueryString["Username"], int.Parse(Current.Text));
            Response.Redirect("UserProfile?Username=" + query);


        }
        protected void Like_PL(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            localhost.Links item = new localhost.Links();
            item.AddLike(Request.QueryString["Username"], int.Parse(Current.Text));
            Label3.Text = "you have liked this playlist!";
            PL_likes.Text = item.GetLikes(Request.QueryString["Username"], int.Parse(Current.Text)).ToString();
        }
        protected void Load_Images()
        {
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Link, Link_order FROM links_tbl WHERE Username = @usr AND List_number = @num ORDER BY Link_order ASC";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer2.Parameters.AddWithValue("@num", Current.Text);
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
                dr["count"] = Drdr2.GetValue(1);
                dt.Rows.Add(dr);
            }
            if (!dataSet.Tables.Contains("images"))
                dataSet.Tables.Add(dt);
            dataSet.Tables["images"].AcceptChanges();
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
                //Save.Visible = true;
            }
            else
            {
                YoutubeData.Visible = true;
                YoutubeThumbnail.Visible = false;
                //Save.Visible = false;
            }
            foreach (RepeaterItem item in YoutubeThumbnail.Items)
            {
                CheckBox checkbox = (CheckBox)item.FindControl("CheckDelete");
                checkbox.Visible = false;
            }
            delete_btn.Visible = false;
        }
        protected void Button_Delete(object sender, EventArgs e)
        {
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < YoutubeThumbnail.Items.Count; i++)
            {
                CheckBox chk = YoutubeThumbnail.Items[i].FindControl("CheckDelete") as CheckBox;
                if (chk.Checked)
                {
                    st.Push(i);
                }
            }
            while (st.Count > 0)
            {
                int i = st.Pop();
                Image img = ((Image)YoutubeThumbnail.Items[i].FindControl("img"));
                string order = ((Label)YoutubeThumbnail.Items[i].FindControl("img_number")).Text;
                string url = img.ImageUrl;
                int found = url.IndexOf("vi/") + 3;
                int finish = url.IndexOf("/default.jpg");
                int last = finish - found;
                string link = url.Substring(found, last);
                OleDbConnection con2 = new OleDbConnection();
                con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con2.Open();
                string sqlstring2 = @"Delete * FROM links_tbl WHERE Username = @usr AND Link = @link AND Link_order = @order AND List_number = @num";
                OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
                conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
                conSer2.Parameters.AddWithValue("@link", link);
                conSer2.Parameters.AddWithValue("@order", int.Parse(order));
                conSer2.Parameters.AddWithValue("@num", Current.Text);
                OleDbDataReader Drdr2 = conSer2.ExecuteReader();
                con2.Close();
                Help_Delete(i);
                
            }
            Response.Redirect("UserProfile?Username=" + query);
        }
        private void Help_Delete(int order)
        {
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Link, Link_order FROM links_tbl WHERE Username = @usr AND List_number = @num AND Link_order > @order";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer2.Parameters.AddWithValue("@order", order);
            conSer2.Parameters.AddWithValue("@num", Current.Text);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            while (Drdr2.Read())
            {
                OleDbConnection con3 = new OleDbConnection();
                con3.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con3.Open();
                string sqlstring3 = @"UPDATE links_tbl SET Link_Order = @count1 WHERE Username = @usr AND Link = @link AND Link_Order = @count2 AND List_number = @num";
                using (OleDbCommand conSer3 = new OleDbCommand(sqlstring3, con3))
                {
                    conSer3.Parameters.AddWithValue("@count1", (int.Parse(Drdr2.GetValue(1).ToString()) - 1));
                    conSer3.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
                    conSer3.Parameters.AddWithValue("@link", Drdr2.GetString(0));
                    conSer3.Parameters.AddWithValue("@count2", int.Parse(Drdr2.GetValue(1).ToString()));
                    conSer3.Parameters.AddWithValue("@num", Current.Text);
                    int Check = 0;
                    Check = conSer3.ExecuteNonQuery();

                }
                con3.Close();
            }
            con2.Close();
        }
        [WebMethod]
        public static void UpdateImagesOrder(List<ImageDTO> d)
        {
                OleDbConnection con2 = new OleDbConnection();
                con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con2.Open();
                string sqlstring2 = @"Delete * FROM links_tbl WHERE Username = @usr AND List_number = @num";
                OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
                conSer2.Parameters.AddWithValue("@usr", query);
                conSer2.Parameters.AddWithValue("@num", current1);
                OleDbDataReader Drdr2 = conSer2.ExecuteReader();
                con2.Close();

                OleDbConnection con1 = new OleDbConnection();
                con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con1.Open();
                foreach (ImageDTO row in d)
                {
                    string url = row.id;
                    int found = url.IndexOf("vi/") + 3;
                    int finish = url.IndexOf("/default.jpg");
                    int last = finish - found;
                    string link = url.Substring(found, last);
                    string sqlstring = @"INSERT INTO links_tbl (Username, Link, Link_order, List_number) values (@usr,@link,@order,@num)";
                    OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
                    conSer.Parameters.AddWithValue("@usr", query);
                    conSer.Parameters.AddWithValue("@link", link);
                    conSer.Parameters.AddWithValue("@order", row.order);
                    conSer.Parameters.AddWithValue("@num", current1);
                int Check = 0;
                    Check = conSer.ExecuteNonQuery();
                }
                con1.Close();
                HttpContext.Current.Response.Redirect("UserProfile?Username=" + query);
        }
    }
}