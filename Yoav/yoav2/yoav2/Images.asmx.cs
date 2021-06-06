using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace yoav2
{
    /// <summary>
    /// Summary description for Images
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Images : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        public class ImageDTO
        {
            public string id { get; set; }
            public int order { get; set; }
        }
        public void UpdateImagesOrder(List<ImageDTO> d)
        {
            hey.Text = "something is happening";
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Request.PhysicalApplicationPath + "\\Yoav_DB.accdb";
            con2.Open();
            foreach (ImageDTO img in d)
            {
                //define procedure
                string sqlstring2 = @"UPDATE links_tbl SET Link_Order = @count1 WHERE Link = @link AND Username = @usr";
                using (OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2))
                {
                    conSer2.Parameters.AddWithValue("@count1", img.order);
                    conSer2.Parameters.AddWithValue("@usr", Request.QueryString["Username"]);
                    conSer2.Parameters.AddWithValue("@link", img.id);
                    int Check = 0;
                    Check = conSer2.ExecuteNonQuery();
                }
            }
            con2.Close();
        }
    }
}
