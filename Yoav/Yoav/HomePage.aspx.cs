using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;

namespace Yoav
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            localhost.Links item = new localhost.Links();
            DataTable dt = item.MostLikes();
            DataListLikes.DataSource = dt;
            DataListLikes.DataBind();
        }
        protected void Search_click(object sender, EventArgs e)
        {
            string username = Search.Text;
            Response.Redirect("SearchUsers.aspx?Username=" + username);
        }
        protected void DataListLikes_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Profile")
            {
                DataListLikes.SelectedIndex = e.Item.ItemIndex;
                string username = ((Label)DataListLikes.SelectedItem.FindControl("User")).Text;
                Response.Redirect("UserProfile.aspx?Username=" + username);
                
            }
        }
    }
}