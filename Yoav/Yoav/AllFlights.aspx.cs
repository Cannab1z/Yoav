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

public partial class AllFlights : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"provider=Microsoft.Jet.OleDb.4.0; Data source=" + Server.MapPath("") + "\\mytable.mdb";
            con1.Open();
            string sqlstring = "select * from tblflights ORDER BY Rnumoffl Desc";
            OleDbCommand ConSer = new OleDbCommand(sqlstring, con1);
            OleDbDataReader Drdr = ConSer.ExecuteReader();
            //DataListProd.DataSource = Drdr;
            //DataListProd.DataBind();
            con1.Close();
        }
    }
    protected void DataListProd_ItemCommand(object source, DataListCommandEventArgs e)
    {
       
        //Response.Write(DataListProd.DataKeys[e.Item.ItemIndex].ToString());
    }
}
