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
        public int GetPlaylistNumber(string username)
        {
            int playlist_number = 0;
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\playlist.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Playlist_number FROM Playlists WHERE Username = @usr ORDER BY Playlist_number ASC";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", username);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            while (Drdr2.Read())
            {
                playlist_number = int.Parse(Drdr2["Playlist_number"].ToString());
            }
            con2.Close();
            return playlist_number;
        }
        [WebMethod]
        public string GetPlaylistName(string username, int num)
        {
            string name = "";
            OleDbConnection con2 = new OleDbConnection();
            con2.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\playlist.accdb";
            con2.Open();
            string sqlstring2 = @"SELECT Playlist_name FROM Playlists WHERE Username = @usr AND Playlist_number = @num";
            OleDbCommand conSer2 = new OleDbCommand(sqlstring2, con2);
            conSer2.Parameters.AddWithValue("@usr", username);
            conSer2.Parameters.AddWithValue("@num", num);
            OleDbDataReader Drdr2 = conSer2.ExecuteReader();
            while (Drdr2.Read())
            {
               name = Drdr2["Playlist_name"].ToString();
            }
            con2.Close();
            return name;
        }
        [WebMethod]
        public void AddPlaylist(string username, string name)
        {
            int num = GetPlaylistNumber(username);
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + HttpContext.Current.Request.PhysicalApplicationPath + "\\playlist.accdb";
            con1.Open();
            string sqlstring = @"INSERT INTO Playlists (Username ,Playlist_name, Playlist_number) values (@usr,@name,@num)";
            OleDbCommand conSer = new OleDbCommand(sqlstring, con1);
            conSer.Parameters.AddWithValue("@usr", username);
            conSer.Parameters.AddWithValue("@name", name);
            conSer.Parameters.AddWithValue("@num", num+1);
            int Check = 0;
            Check = conSer.ExecuteNonQuery();
            con1.Close();
        }
        [WebMethod]
        public void DeletePlaylist(string username, int num)
        { 
            
        }
    }
}
