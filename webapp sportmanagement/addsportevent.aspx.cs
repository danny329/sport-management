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
    public partial class addsportevent : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["name"] == null)
            {
                Response.Redirect("login.aspx");
            }
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String sportname = TB1.Text;
            String sportdesc = TB2.Text;
            String maxplyr = TB3.Text;
            SqlCommand cmd = new SqlCommand("insert into sporteventtable values (@spn,@spd,@max)", con);
            cmd.Parameters.AddWithValue("@spn", sportname);
            cmd.Parameters.AddWithValue("@spd", sportdesc);
            cmd.Parameters.AddWithValue("@max", Convert.ToInt32(maxplyr));
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
              
                con.Close();
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT ADDED!', '"+sportname + " successfully created!', 'success');", true);

                



            }
            catch (Exception ex) { Response.Write(ex); }
        }
       


        protected void removesport_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!', 'REMOVING A SPORT MAY RESULT IN REMOVING ALL THE PARTICIPANTS AND TOURNAMENT INFORMATION FOR THE PARTICULAR SPORT!');", true);
            BindData();
        }
        protected void addsport_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        protected void Backsportview_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        //deletesport starts here...
        public void BindData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from sporteventtable", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            else
            {
                DataTable dat = new DataTable();
                GridView3.DataSource = dat;
                GridView3.DataBind();
            }
            con.Close();
        }
        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            string id = GridView3.DataKeys[e.RowIndex].Value.ToString();
            
            con.Open();
            SqlCommand cmd = new SqlCommand("select sportname from sporteventtable where sportid='" + id + "'", con);
            SqlCommand cmd1 = new SqlCommand("delete from groupsporteventstudentlist where exists (select token from groupsportdetail where sportid='" + id + "')", con);
            SqlCommand cmd2 = new SqlCommand("delete from groupsportdetail where sportid='" + id + "'", con);
            SqlCommand cmd3 = new SqlCommand("delete FROM scoreboardtable where sid='" + id + "'", con);
            SqlCommand cmd4 = new SqlCommand("delete FROM tournament_sport_table where sid='" + id + "'", con);
            SqlCommand cmd5 = new SqlCommand("delete FROM sport_team_list where sportid='" + id + "'", con);
            SqlCommand cmd6 = new SqlCommand("delete FROM sporteventtable where sportid='" + id + "'", con);

            String sportname = (String) cmd.ExecuteScalar();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();
            cmd6.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT DELETED!', '" + sportname + " successfully created!', 'success');", true);
            MultiView1.ActiveViewIndex = 2;
            BindData();

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void home_Click(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Redirect("admin_dashboard.aspx");
            }
        }
    }
}