using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class AllUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OleDbConnection con4 = new OleDbConnection();
            con4.ConnectionString = @"provider=Microsoft.Jet.OleDb.4.0; Data source=" + Server.MapPath("") + "\\mytable.mdb";
            con4.Open();
            string sqlstring = "select * from tbl order by Ulastname deSC";
            OleDbCommand ConSer = new OleDbCommand(sqlstring, con4);
            OleDbDataReader Drdr4 = ConSer.ExecuteReader();
            Repeaterofusers.DataSource = Drdr4;
            Repeaterofusers.DataBind();
            con4.Close();
            
        }
    }

}

