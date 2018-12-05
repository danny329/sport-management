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
    public partial class removeplayers : System.Web.UI.Page
    {
        
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                BindData();
                con.Open();
                SqlCommand cmd = new SqlCommand("select tournamentid,tname from addtournamenttable", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DDLN.DataSource = dr;
                DDLN.Items.Clear();
                DDLN.DataTextField = "tname";
                DDLN.DataValueField = "tournamentid";
                DDLN.DataBind();
                con.Close();
                DDLN.Items.Insert(0, new ListItem("--Select tournament--", "0"));
            }
        }

        protected void DDL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select dummystudenttable.studentid,dummystudenttable.studentname from scoreboardtable JOIN dummystudenttable ON scoreboardtable.studentid=dummystudenttable.studentid where tid=@tid", con);
            cmd.Parameters.AddWithValue("@tid", DDLN.SelectedValue.ToString());
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            SqlCommand cmd1 = new SqlCommand("select groupsporteventstudentlist.studentid, dummystudenttable.studentname from groupsporteventstudentlist inner join dummystudenttable on groupsporteventstudentlist.studentid=dummystudenttable.studentid inner join groupsportdetail on groupsporteventstudentlist.token=groupsportdetail.token where groupsportdetail.tournamentid=@tid", con);
            cmd1.Parameters.AddWithValue("@tid", DDLN.SelectedValue.ToString());
            SqlDataAdapter dr1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            dr1.Fill(ds);
            DDLN1.DataSource = ds;
            DDLN1.Items.Clear();
            DDLN1.DataTextField = "studentname";
            DDLN1.DataValueField = "studentid";
            DDLN1.DataBind();
            con.Close();
            DDLN1.Items.Insert(0, new ListItem("--please select STUDENT--", "0"));
        }
        protected void DDL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
            BindData2();
        }

        public void BindData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select scoreboardtable.studentid,dummystudenttable.studentname,sporteventtable.sportname,sporteventtable.sportid from scoreboardtable  INNER JOIN dummystudenttable ON dummystudenttable.studentid = scoreboardtable.studentid INNER JOIN sporteventtable ON scoreboardtable.sid=sporteventtable.sportid where scoreboardtable.tid='" + DDLN.SelectedValue.ToString() + "' and scoreboardtable.studentid='" + DDLN1.SelectedValue.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            con.Close();
        }
        public void BindData2()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select groupsporteventstudentlist.studentid, dummystudenttable.studentname,sporteventtable.sportid,sporteventtable.sportname,groupsportdetail.token from groupsporteventstudentlist inner join dummystudenttable on groupsporteventstudentlist.studentid=dummystudenttable.studentid inner join groupsportdetail on groupsporteventstudentlist.token=groupsportdetail.token inner join sporteventtable on sporteventtable.sportid=groupsportdetail.sportid where groupsportdetail.tournamentid='" + DDLN.SelectedValue.ToString() + "' and dummystudenttable.studentid='" + DDLN1.SelectedValue.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            con.Close();
        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView2.DataKeys[e.RowIndex].Value.ToString();
            
            
            con.Open();
            
            SqlCommand cmd = new SqlCommand("delete FROM groupsporteventstudentlist where  token='" + id + "' and studentid='" + DDLN1.SelectedValue.ToString() + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('DELETED!', ' successfully deleted!', 'success');", true);
            BindData2();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            
            //Response.Write(id);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select studentname from dummystudenttable where studentid='" + id + "'", con);
            String name = (String)cmd1.ExecuteScalar();
            SqlCommand cmd = new SqlCommand("delete FROM scoreboardtable where tid='" + DDLN.SelectedValue.ToString() + "' and sid='" + id + "' and studentid='" + DDLN1.SelectedValue.ToString() + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('DELETED!', '" + name + " successfully deleted!', 'success');", true);
            BindData();
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