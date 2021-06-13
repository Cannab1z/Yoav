using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

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
        private List<ImageDTO> last = new List<ImageDTO>();

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
        public void Get_Order(List<ImageDTO> d)
        {
            last = d;
        }
        [WebMethod]
        public List<ImageDTO> Final_Order()
        {
            return last;
        }
    }
}
