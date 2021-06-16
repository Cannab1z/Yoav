using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yoav
{
    public partial class new_playlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            name.Text = Session["user"].ToString();
        }
        protected void AddPL_Click(object sender, EventArgs e)
        {
            localhost.Links connect = new localhost.Links();
            connect.AddPlaylist(Session["user"].ToString(), PL_text.Text);
            Response.Redirect("UserProfile.aspx?Username=" + Session["user"]);
        }
    }
}