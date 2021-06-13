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
            public int start { get; set; }
        }
        private localhost.Links order = new localhost.Links();
        private System.Data.DataSet dataSet = new DataSet();
        private int count = 0;
        public static string query { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            query = Request.QueryString["Username"];
            if (Request.QueryString["Username"] == null)
            {
                Response.Redirect("Errorpage.aspx");
            }
            if (Session["user"] != null)
            {
                if (Session["user"].ToString() == Request.QueryString["Username"] || Session["Admin"].ToString() == "true")
                {
                    Add_link.Visible = true;
                    User_update.Visible = true;
                    YoutubeLink.Visible = true;
                    Link_Edit.Visible = true;
                    Edit_Delete.Visible = true;
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
            foreach (DataRow item in dataSet.Tables["youtube"].Rows)
                {
                    Response.Write(item[1]);
                }
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
            string sqlstring = @"INSERT INTO links_tbl (Username ,Link, Link_Order) values (@usr,@link,@count)";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer.Parameters.AddWithValue("@link", link);
            conSer.Parameters.AddWithValue("@count", (count + 1));
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
                Save.Visible = true;
            }
            else
            {
                YoutubeData.Visible = true;
                YoutubeThumbnail.Visible = false;
                Save.Visible = false;
            }
            foreach (RepeaterItem item in YoutubeThumbnail.Items)
            {
                CheckBox checkbox = (CheckBox)item.FindControl("CheckDelete");
                checkbox.Visible = false;
            }
            delete_btn.Visible = false;
        }
        protected void Save_Edit(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            localhost.Links save = new localhost.Links();
            DataTable dt = new DataTable("images");
            dt = save.Final_Order();
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            string sqlstring2 = @"Delete * FROM links_tbl WHERE Username = @usr";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            con2.Close();
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con1.Open();
            foreach (DataRow row in dt.Rows)
            {
                string sqlstring = @"INSERT INTO links_tbl (Username, Link, Link_order) values (@usr,@link,@order)";
                OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
                conSer.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
                conSer.Parameters.AddWithValue("@link", row[0]);
                conSer.Parameters.AddWithValue("@order", int.Parse(row[2].ToString()));
                int Check = 0;
                Check = conSer.ExecuteNonQuery();
            }

            con1.Close();
            Response.Redirect("UserProfile?Username=" + query);
        }
        protected void Button_Delete(object sender, EventArgs e)
        {
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < YoutubeThumbnail.Items.Count; i++)
            {
                /*foreach (DataRow hey in dataSet.Tables["youtube"].Rows)
                {
                    //Response.Write(hey[1]);
                }*/
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
                string sqlstring2 = @"Delete * FROM links_tbl WHERE Username = @usr AND Link = @link AND Link_order = @order";
                OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
                conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
                conSer2.Parameters.AddWithValue("@link", link);
                conSer2.Parameters.AddWithValue("@order", int.Parse(order));
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
            string sqlstring2 = @"SELECT Link, Link_order FROM links_tbl WHERE Username = @usr AND Link_order > @order";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
            conSer2.Parameters.AddWithValue("@order", order);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            while (Drdr2.Read())
            {
                OleDbConnection con3 = new OleDbConnection();
                con3.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
                con3.Open();
                string sqlstring3 = @"UPDATE links_tbl SET Link_Order = @count1 WHERE Username = @usr AND Link = @link AND Link_Order = @count2";
                using (OleDbCommand conSer3 = new OleDbCommand(sqlstring3, con3))
                {
                    conSer3.Parameters.AddWithValue("@count1", (int.Parse(Drdr2.GetValue(1).ToString()) - 1));
                    conSer3.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
                    conSer3.Parameters.AddWithValue("@link", Drdr2.GetString(0));
                    conSer3.Parameters.AddWithValue("@count2", int.Parse(Drdr2.GetValue(1).ToString()));
                    int Check = 0;
                    Check = conSer3.ExecuteNonQuery();

                }
                con3.Close();
            }
            con2.Close();
        }
        [WebMethod]
        //for tommorow: it is currently only doing this for 1 image because I have to somehow update their start order, probably with something related to load_image
        public static void UpdateImagesOrder(List<ImageDTO> d)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                localhost.Links images = new localhost.Links();
                string[] links = new string[d.Count];
                int[] start_order = new int[d.Count];
                int[] order = new int[d.Count];
                int count = 0;
                foreach (ImageDTO item in d)
                {
                    links[count] = item.id;
                    start_order[count] = item.start;
                    order[count] = item.order;
                }
                images.Get_Order(links,start_order,order);
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write(e.ToString());
            }

            /*
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            Page page = HttpContext.Current.Handler as Page;
            try
            {
                foreach (ImageDTO img in d)
                {
                    string order = "";
                    int found = img.id.IndexOf("vi/") + 3;
                    int finish = img.id.IndexOf("/default.jpg");
                    int last = finish - found;
                    string youtube = img.id.Substring(found, last);
                    string sqlstring2 = @"UPDATE links_tbl SET Link_Order = @count1 WHERE Username = @usr AND Link = @link AND Link_Order = @count2";
                    using (OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2))
                    {
                        conSer2.Parameters.AddWithValue("@count1", int.Parse(img.order.ToString()));
                        conSer2.Parameters.AddWithValue("@usr", query);
                        conSer2.Parameters.AddWithValue("@link", youtube);
                        conSer2.Parameters.AddWithValue("@count2", int.Parse(img.start.ToString()));
                        int Check = 0;
                        Check = conSer2.ExecuteNonQuery();
                        order += img.id;
                        HttpContext.Current.Response.Write(Check);
                    }
                    //HttpContext.Current.Response.Write(img.order);
                    UserProfile profile = new UserProfile();
                    //profile.Load_Images();
                }
                foreach (DataRow item in dataSet.Tables["youtube"].Rows)
                {
                    Response.Write(item[1]);
                }

            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("hey");
            }
            con2.Close();*/
        }
    }
}