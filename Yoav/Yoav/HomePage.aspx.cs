using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yoav
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Search_click(object sender, EventArgs e)
        {
            string username = Search.Text;
            Response.Redirect("SearchUsers.aspx?Username=" + username);
        }
        protected void Profile_click(object sender, EventArgs e)
        {
            Response.Redirect("SearchUsers.aspx?Username=idankid");
        }
    }
}