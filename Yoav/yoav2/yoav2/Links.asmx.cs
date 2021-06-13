using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;

namespace yoav2
{
    /// <summary>
    /// Summary description for Links
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Links : System.Web.Services.WebService
    {
        public class ImageDTO
        {
            public string id { get; set; }
            public int order { get; set; }
            public int start { get; set; }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "hey";
        }
        [WebMethod]
        public string GetYoutubeId(string link)
        {
            int found = 0;
            if (link.IndexOf("?v=") > -1)
            {
                found = link.IndexOf("?v=") + 3;
            }
            else if (link.IndexOf("youtu.be/") > -1)
            {
                found = link.IndexOf("youtu.be/") + 9;
            }
            string youtube_id = link.Substring(found);
            return youtube_id;
        }
        [WebMethod]
        public void Get_Order(string[] links, int[] start_order, int[] order)
        {
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Server.MapPath("") + "\\order.accdb";
            con2.Open();
            string sqlstring2 = @"Delete * FROM order_tbl";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            con2.Close();
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Server.MapPath("") + "\\order.accdb";
            con1.Open();
            for(int i = 0; i < links.Length; i++)
            {
                string sqlstring = @"INSERT INTO order_tbl (Link, Start_order, End_order) values (@link,@start,@order)";
                OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
                conSer.Parameters.AddWithValue("@start", start_order[i]);
                conSer.Parameters.AddWithValue("@link", links[i]);
                conSer.Parameters.AddWithValue("@order", order[i]);
                int Check = 0;
                Check = conSer.ExecuteNonQuery();
            }
            
            con1.Close();
        }
        [WebMethod]
        public DataTable Final_Order()
        {
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Server.MapPath("") + "\\order.accdb";
            con1.Open();
            string sqlstring2 = @"SELECT * FROM order_tbl";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con1);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            DataTable dt = new DataTable("images");
            DataColumn dc = new DataColumn("link");
            dt.Columns.Add(dc);
            dc = new DataColumn("start_order");
            dt.Columns.Add(dc);
            dc = new DataColumn("order");
            dt.Columns.Add(dc);
            while (Drdr2.Read())
            {
                DataRow dr = dt.NewRow();
                dr["link"] = Drdr2.GetString(0);
                dr["start_order"] = Drdr2.GetValue(1);
                dr["order"] = Drdr2.GetValue(2);
                dt.Rows.Add(dr);
            }
            con1.Close();
            return dt;
        }
    }
}
