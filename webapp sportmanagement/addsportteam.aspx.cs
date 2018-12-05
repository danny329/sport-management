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
    public partial class addsportteam : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                MultiView1.ActiveViewIndex = 0;
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                
              

            }
        }

        protected void addteam_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            con.Open();
            SqlCommand cmd = new SqlCommand("select sportid,sportname from sporteventtable", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DDL25.DataSource = dr;
            DDL25.DataTextField = "sportname";
            DDL25.DataValueField = "sportid";
            DDL25.DataBind();
            con.Close();
            DDL25.Items.Insert(0, new ListItem("--Select sport--", "0"));

        }
        protected void removeteam_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            con.Open();
            SqlCommand cmd = new SqlCommand("select sportid,sportname from sporteventtable", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DDL26.DataSource = dr;
            DDL26.DataTextField = "sportname";
            DDL26.DataValueField = "sportid";
            DDL26.DataBind();
            con.Close();
            DDL26.Items.Insert(0, new ListItem("--Select sport--", "0"));

        }



        //add sport team
        public void BindData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select dummystudenttable.studentid, dummystudenttable.studentname from dummystudenttable where dummystudenttable.studentid NOT IN(select sport_team_list.studentid from sport_team_list )", con);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                DataTable dta= new DataTable();
                GridView1.DataSource = dta;
                GridView1.DataBind();
            }
            con.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String str="";
            
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox CheckBox = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                    if (CheckBox.Checked)
                    {
                        string id = row.Cells[1].Text;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into sport_team_list (sportid,studentid) values('" + DDL25.SelectedValue.ToString() + "', '" + id + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        str = str + id + " ADDED TO " + DDL25.SelectedItem.ToString() + "\\n";

                    }

                }
            }
            if (str == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!', 'NO SELECTION WERE MADE!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT TEAM ADDED!', '" + str + "', 'success');", true);
            }
            BindData();
        }
        protected void DDL25_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }



        //remove sport team
        public void BindDataT()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select dummystudenttable.studentid, dummystudenttable.studentname from dummystudenttable join sport_team_list on dummystudenttable.studentid = sport_team_list.studentid where sport_team_list.sportid='" + DDL26.SelectedValue.ToString() + "'", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView7.DataSource = dt;
                GridView7.DataBind();
            }
            else
            {
                DataTable de = new DataTable();
                GridView7.DataSource = de;
                GridView7.DataBind();
            }

            con.Close();
        }
        protected void DDL26_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataT();
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            String str = "";
            foreach (GridViewRow row in GridView7.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox CheckBox = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                    if (CheckBox.Checked)
                    {
                        string id = row.Cells[1].Text;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("delete from sport_team_list where studentid='" + id + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        str = str + id + " REMOVED from " + DDL26.SelectedItem.ToString()+"\\n";
                        
                    }
                }
            }
            if(str=="")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!', 'NO SELECTION WERE MADE!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT TEAM REMOVED!', '" + str + "', 'success');", true);
            }
            

            BindDataT();
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

        protected void paymentpage_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from paymenttable", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                DataTable de = new DataTable();
                GridView2.DataSource = de;
                GridView2.DataBind();
            }

            con.Close();
        }
    }
}