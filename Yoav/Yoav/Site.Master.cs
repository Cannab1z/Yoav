using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yoav
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                logout_btn.Visible = false;
                register_btn.Visible = true;
                login_btn.Visible = true;
                profile_btn.Visible = false;
            }
            else
            {
                logout_btn.Visible = true;
                register_btn.Visible = false;
                login_btn.Visible = false;
                profile_btn.Visible = true;
            }
        }
        protected void Logout_click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["admin"] = "False";
            Response.Redirect("Login.aspx");
        }
        protected void Login_click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void Register_click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        protected void Profile_click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx?Username=" + Session["user"]);
        }
    }
}