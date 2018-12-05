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
    public partial class addtournament : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                MultiView1.ActiveViewIndex = 0;
                
            }
             
        }
        //change views
        protected void addtournamentviewbutton_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            Calendar1.Visible = false;
            Calendar2.Visible = false;
        }
        protected void edittournamentviewbutton_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            

            BindDatae();
            con.Open();
            SqlCommand cmd = new SqlCommand("select tournamentid,tname from addtournamenttable", con);
            SqlDataReader dr = cmd.ExecuteReader();
            TTN.DataSource = dr;
            TTN.Items.Clear();
            TTN.DataTextField = "tname";
            TTN.DataValueField = "tournamentid";
            TTN.DataBind();
            con.Close();
            TTN.Items.Insert(0, new ListItem("--Select tournament--", "0"));
           

        }
        protected void deletetournamentviewbutton_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            BindData();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!', 'REMOVING A TOURNAMENT RESULT IN REMOVING ALL THE PARTICIPANTS AND EVENTS FOR THE PARTICULAR TOURNAMENT!!');", true);
        }
        //addtournament methods
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox3.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
            TextBox4.Text = "";
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }

        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox4.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String tname = TextBox1.Text;
            String tdesc = TextBox2.Text;
            String tsd = TextBox3.Text;
            String ted = TextBox4.Text;
            SqlCommand cmd = new SqlCommand("insert into addtournamenttable values (@tn,@tsd,@ted,@td)", con);
            cmd.Parameters.AddWithValue("@tn", tname);
            cmd.Parameters.AddWithValue("@tsd", tsd);
            cmd.Parameters.AddWithValue("@ted", ted);
            cmd.Parameters.AddWithValue("@td", tdesc);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                
                con.Close();
                
            }
            catch (Exception ex) { Response.Write(ex); }
            String tid = "";
            try {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select tournamentid from addtournamenttable where tname=@tn", con);
                cmd1.Parameters.AddWithValue("@tn", tname);
                SqlDataReader dr = cmd1.ExecuteReader();
                while(dr.Read())
                {
                     tid = dr["tournamentid"].ToString();
                }
                dr.Close();
               /// Response.Write(tid);
                foreach (ListItem list in CheckBoxList1.Items)
                {
                    if (list.Selected == true)
                    {
                        SqlCommand cmd2 = new SqlCommand("insert into tournament_sport_table values (@tid,@sid)", con);
                        cmd2.Parameters.AddWithValue("@tid", tid);
                        cmd2.Parameters.AddWithValue("@sid", list.Value);
                        cmd2.ExecuteNonQuery();
                    }
                }
                con.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('" + tname + "', 'successfully added tournament!', 'success');", true);
            }
            catch(Exception ex) { Response.Write(ex); }
            MultiView1.ActiveViewIndex = 0;
        }
        protected void backinadtour_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }




        //edit tournament methods
        protected void TTN_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            int n = Convert.ToInt32(TTN.SelectedIndex.ToString());
            if (n==0)
            {
                DataTable de = new DataTable();
                GV1.DataSource = de;
                GV1.DataBind();
                GV2.DataSource = de;
                GV2.DataBind();
                edittournamentmultiview.ActiveViewIndex = -1;
            }
            else
            {
                con.Open();
                SqlCommand smd = new SqlCommand("select tstartdate,tenddate from addtournamenttable where tournamentid= '" + TTN.SelectedValue.ToString() + "'", con);
                SqlDataReader sd = smd.ExecuteReader();
                if (sd.HasRows)
                {
                    while (sd.Read())
                    {
                        DATESTART.Text = sd["tstartdate"].ToString();
                        ENDDATE.Text = sd["tenddate"].ToString();
                    }
                }
                else
                {
                    DATESTART.Text = "";
                    ENDDATE.Text = "";
                }
                
                con.Close();

                BindDatae();
                Bindsport();
                edittournamentmultiview.ActiveViewIndex = 0;
               

            }

        }
        public void Bindsport()
        {
            con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sportname, sportid from sporteventtable where sporteventtable.sportid NOT IN (SELECT tournament_sport_table.sid FROM tournament_sport_table  join sporteventtable  on tournament_sport_table.sid=sporteventtable.sportid where  tournament_sport_table.tid='" + TTN.SelectedValue.ToString() + "')", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                GV1.DataSource = dt1;
                GV1.DataBind();
            }
            else
            {
                DataTable de = new DataTable();
                GV1.DataSource = de;
                GV1.DataBind();
            }

            con.Close();
        }
        public void BindDatae()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sporteventtable.sportname,sporteventtable.sportid from tournament_sport_table JOIN sporteventtable ON tournament_sport_table.sid=sporteventtable.sportid where tournament_sport_table.tid='" + TTN.SelectedValue.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GV2.DataSource = dt;
                GV2.DataBind();
            }
            else
            {
                DataTable de = new DataTable();
                GV2.DataSource = de;
                GV2.DataBind();
            }
            con.Close();
        }
        protected void GV1_OnCheckedChanged(object sender, EventArgs e)
        {


            CheckBox checkbox = (CheckBox)sender;

            checkbox.Checked = true;
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            con.Open();
            SqlCommand cmd = new SqlCommand("select sportname from sporteventtable where sportid='" + row.Cells[2].Text + "'", con);
            SqlCommand cmd2 = new SqlCommand("insert into tournament_sport_table values (@tid,@sid)", con);
            cmd2.Parameters.AddWithValue("@tid", TTN.SelectedValue.ToString());
            cmd2.Parameters.AddWithValue("@sid", row.Cells[2].Text);
            String sportname = (String)cmd.ExecuteScalar();
            cmd2.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT ADDED!', '" + sportname + " successfully added to tournament!', 'success');", true);
            con.Close();
            Bindsport();
            BindDatae();



        }
        protected void GV2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GV2.DataKeys[e.RowIndex].Value.ToString();
            con.Open();
            SqlCommand cmd5 = new SqlCommand("select max_players from sporteventtable where sportid='" + id + "'", con);
            int max = (int)cmd5.ExecuteScalar();
            con.Close();
            if (max == 1)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("delete FROM scoreboardtable where tid='" + TTN.SelectedValue.ToString() + "' and sid='" + id + "'", con);
                
                SqlCommand cmd3 = new SqlCommand("delete FROM tournament_sport_table where tid='" + TTN.SelectedValue.ToString() + "' and sid='" + id + "'", con);
                SqlCommand cmd = new SqlCommand("select sportname from sporteventtable where sportid='" + id + "'", con);
                String sportname = (String)cmd.ExecuteScalar();
                cmd1.ExecuteNonQuery();
                
                cmd3.ExecuteNonQuery();
                
                con.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT REMOVED!', '" + sportname + " successfully removed from tournament!', 'success');", true);
                BindDatae();
                Bindsport();
            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("delete from groupsporteventstudentlist where exists (select token from groupsportdetail where sportid='" + id + "' and tournamentid='" + TTN.SelectedValue.ToString() + "')", con);
                SqlCommand cmd2 = new SqlCommand("delete from groupsportdetail where sportid='" + id + "' and tournamentid='" + TTN.SelectedValue.ToString() + "'", con);
                SqlCommand cmd3 = new SqlCommand("delete FROM tournament_sport_table where tid='" + TTN.SelectedValue.ToString() + "' and sid='" + id + "'", con);
                SqlCommand cmd = new SqlCommand("select sportname from sporteventtable where sportid='" + id + "'", con);
                String sportname = (String)cmd.ExecuteScalar();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                
                con.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT REMOVED!', '" + sportname + " successfully removed from tournament!', 'success');", true);
                BindDatae();
                Bindsport();

            }
            

        }
        protected void B2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("update addtournamenttable set tstartdate='" + DATESTART.Text + "', tenddate='" + ENDDATE.Text + "' where tournamentid= '" + TTN.SelectedValue.ToString() + "'", con);
            cmd.ExecuteNonQuery();

            con.Close();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('UPDATES!', 'successfully updated changes for the tournament!', 'success');", true);
        }






        //deletetournament starts here...
        public void BindData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from addtournamenttable", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            con.Close();
        }
        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            
            string id = GridView3.DataKeys[e.RowIndex].Value.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("select tname from addtournamenttable where tournamentid='" + id + "'", con);
            
            SqlCommand cmd1 = new SqlCommand("delete from groupsporteventstudentlist where exists (select token from groupsportdetail where tournamentid='" + id + "')", con);
            SqlCommand cmd2 = new SqlCommand("delete from groupsportdetail where tournamentid='" + id + "'", con);
            SqlCommand cmd3 = new SqlCommand("delete FROM scoreboardtable where tid='" + id + "'", con);
            SqlCommand cmd4 = new SqlCommand("delete FROM tournament_sport_table where tid='" + id + "'", con);
            SqlCommand cmd5 = new SqlCommand("delete FROM addtournamenttable where tournamentid='" + id + "'", con);

            String tour = (String)cmd.ExecuteScalar();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('" + tour + "', ' successfully removed from tournament!', 'success');", true);
            con.Close();
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

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date <= Calendar1.SelectedDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            if (e.Day.Date >= DateTime.Now.AddMonths(3))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }


}