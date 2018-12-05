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
    public partial class viewscoreboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindData();
                con.Open();
                SqlCommand cmd = new SqlCommand("select tournamentid,tname from addtournamenttable", con);
                SqlDataReader dr = cmd.ExecuteReader();
                Tour.DataSource = dr;
                Tour.Items.Clear();
                Tour.DataTextField = "tname";
                Tour.DataValueField = "tournamentid";
                Tour.DataBind();
                con.Close();
                Tour.Items.Insert(0, new ListItem("--Select tournament--", "0"));
            }
        }
        protected void Tour_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select sportid,sportname,max_players from sporteventtable JOIN tournament_sport_table ON sporteventtable.sportid=tournament_sport_table.sid where tid=@tid", con);
            cmd.Parameters.AddWithValue("@tid", Tour.SelectedValue.ToString());
            SqlDataReader dr = cmd.ExecuteReader();

            DDL2.DataSource = dr;
            DDL2.Items.Clear();
            DDL2.DataTextField = "sportname";
            DDL2.DataValueField = "sportid";
            DDL2.DataBind();
            con.Close();
            DDL2.Items.Insert(0, new ListItem("--please select sport--", "0"));
        }
        protected void DDL2_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cm = new SqlCommand("select max_players from sporteventtable where sportid=@id ", con);
            cm.Parameters.AddWithValue("@id", DDL2.SelectedValue.ToString());
            int max = (int)cm.ExecuteScalar();
            con.Close();
            if (max == 1)
            {
                GridView2.Visible = false;
                GridView1.Visible = true;
                BindData();

            }
            else
            {
                GridView1.Visible = false;
                GridView2.Visible = true;
                BindDatagroup();


            }



        }
        
        public void BindDatagroup()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select groupsportdetail.teamname, groupsporteventstudentlist.studentid, groupsporteventstudentlist.score from groupsportdetail join groupsporteventstudentlist on groupsportdetail.token=groupsporteventstudentlist.token where groupsportdetail.tournamentid='" + Tour.SelectedValue.ToString() + "' and groupsportdetail.sportid='" + DDL2.SelectedValue.ToString() + "' order by groupsportdetail.teamname", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            con.Close();
        }
        public void BindData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select dummystudenttable.studentid,dummystudenttable.studentname,scoreboardtable.score from dummystudenttable JOIN scoreboardtable ON scoreboardtable.studentid=dummystudenttable.studentid where tid='" + Tour.SelectedValue.ToString() + "' and sid='" + DDL2.SelectedValue.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            con.Close();
        }
     


       

       
       



    }
}
