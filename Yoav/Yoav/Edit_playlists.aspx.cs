using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Net;

namespace Yoav
{
    public partial class Edit_playlists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = Request.QueryString["Username"];
                if (Session["user"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (!(Session["user"].ToString() == username || Session["admin"] == "true"))
                {
                    Response.Redirect("Errorpage.aspx");
                }
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                localhost.Links item = new localhost.Links();
                DataTable dt = item.GetDB(Request.QueryString["Username"]);
                DataListPlaylists.DataSource = dt;
                DataListPlaylists.DataBind();
            }
            
        }
        protected void DataListPlaylists_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Update_command")
            {
                DataListPlaylists.SelectedIndex = e.Item.ItemIndex;
                string name = ((TextBox)DataListPlaylists.SelectedItem.FindControl("Name")).Text;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                localhost.Links item = new localhost.Links();
                item.Update_Name(Request.QueryString["Username"], int.Parse(((Label)DataListPlaylists.SelectedItem.FindControl("Number")).Text), ((TextBox)DataListPlaylists.SelectedItem.FindControl("Name")).Text);
                Response.Redirect("Edit_playlists?Username=" + Request.QueryString["Username"]);
            }
        }
    }
}