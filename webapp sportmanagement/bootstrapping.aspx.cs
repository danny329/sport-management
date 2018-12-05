using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace webapp_sportmanagement
{
    public partial class start_with_bootstrap : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        public int i=2;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            String location = Server.MapPath("~/backup_folder/");
          //  String file = "master";
            String bkq = "backup database newdb to disk ='" + location + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'";
            SqlCommand sdb = new SqlCommand(bkq, con);
            sdb.ExecuteNonQuery();
            con.Close();
            //ConnectionString (webapp sportmanagement)
        }
        //C:\USERS\DANIEL\SOURCE\REPOS\SPORT MANGEMENT\WEBAPP SPORTMANAGEMENT\APP_DATA\NEWDB.MDF


    }
}