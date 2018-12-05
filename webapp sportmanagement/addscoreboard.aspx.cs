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
    public partial class addscoreboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("select tournamentid,tname from addtournamenttable", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DDL1.DataSource = dr;
                DDL1.Items.Clear();
                DDL1.DataTextField = "tname";
                DDL1.DataValueField = "tournamentid";
                DDL1.DataBind();
                con.Close();
                DDL1.Items.Insert(0, new ListItem("--Select tournament--", "0"));
                
                
            }
            
        }

        //change views
      








        protected void DDL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select sportid,sportname,max_players from sporteventtable JOIN tournament_sport_table ON sporteventtable.sportid=tournament_sport_table.sid where tid=@tid", con);
            cmd.Parameters.AddWithValue("@tid", DDL1.SelectedValue.ToString());
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
                team.Visible = false;
                teamlist.Visible = false;
                BindData();
                
            }
            else
            {
                GridView1.Visible = false;
                team.Visible = true;
                teamlist.Visible = true;
                con.Open();
                SqlCommand cmd = new SqlCommand("select groupsportdetail.teamname, groupsportdetail.token from groupsportdetail where groupsportdetail.tournamentid=@tid and groupsportdetail.sportid=@sid", con);
                cmd.Parameters.AddWithValue("@tid", DDL1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@sid", DDL2.SelectedValue.ToString());
                SqlDataReader dr = cmd.ExecuteReader();

                teamlist.DataSource = dr;
                teamlist.Items.Clear();
                teamlist.DataTextField = "teamname";
                teamlist.DataValueField = "token";
                teamlist.DataBind();
                con.Close();
                teamlist.Items.Insert(0, new ListItem("--please select a team--", "0"));
            }
            
           
       
        }
        protected void teamlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDatagroup();
            GridView1.Visible = false;
            GridView2.Visible = true;
        }
        public void BindDatagroup()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select groupsportdetail.teamname, groupsporteventstudentlist.studentid, groupsporteventstudentlist.score from groupsportdetail join groupsporteventstudentlist on groupsportdetail.token=groupsporteventstudentlist.token where groupsportdetail.tournamentid='" + DDL1.SelectedValue.ToString() + "' and groupsportdetail.sportid='" + DDL2.SelectedValue.ToString() + "' and groupsportdetail.token='" + teamlist.SelectedValue.ToString() + "'", con);
           
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
            SqlDataAdapter sda = new SqlDataAdapter("select dummystudenttable.studentid,dummystudenttable.studentname,scoreboardtable.score from dummystudenttable JOIN scoreboardtable ON scoreboardtable.studentid=dummystudenttable.studentid where tid='" + DDL1.SelectedValue.ToString() + "' and sid='" + DDL2.SelectedValue.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            con.Close();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string studentid = (row.Cells[1].Controls[0] as TextBox).Text;
            string score = (row.Cells[3].Controls[0] as TextBox).Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("Update scoreboardtable set score=@score where studentid=@studentid and tid=@tid and sid=@sid", con);
            cmd.Parameters.AddWithValue("@tid", DDL1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@sid", DDL2.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@score", score);
            cmd.Parameters.AddWithValue("@studentid", studentid);
            cmd.ExecuteNonQuery();
            con.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            BindData();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            BindDatagroup();
        }
        protected void GridView2_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView2.Rows[e.RowIndex];

            string studentid = (row.Cells[2].Controls[0] as TextBox).Text;
            string score = (row.Cells[3].Controls[0] as TextBox).Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("Update groupsporteventstudentlist set score=@score where studentid=@studentid and token=@token", con);
            cmd.Parameters.AddWithValue("@token", teamlist.SelectedValue.ToString());
            
            cmd.Parameters.AddWithValue("@score", score);
            cmd.Parameters.AddWithValue("@studentid", studentid);
            cmd.ExecuteNonQuery();
            con.Close();

           
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView2.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            BindDatagroup();
        }
        protected void GridView2_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView2.EditIndex = -1;
            BindDatagroup();
        }



        protected void Button1_Click(object sender, EventArgs e)
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

