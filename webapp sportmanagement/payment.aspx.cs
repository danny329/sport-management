using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace webapp_sportmanagement
{
    public partial class payment : System.Web.UI.Page
    {
       public int pricet;
       
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                MultiView1.ActiveViewIndex = 0;
                datalist();
                divtag.Visible = false;
            }
          
           
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            MultiView1.ActiveViewIndex = 1;
            
        }
        void datalist()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select pname,pid from producttable", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DDL26.DataSource = dr;
            DDL26.DataTextField = "pname";
            DDL26.DataValueField = "pid";
            DDL26.DataBind();

            con.Close();
            DDL26.Items.Insert(0, new ListItem("--Select product--", "0"));
        }

        protected void DDL26_SelectedIndexChanged(object sender, EventArgs e)
        {
            //datalist();
           //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT TEAM REMOVED!', '" + DDL26.SelectedValue.ToString() + "', 'success');", true);
           //

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select pprice from producttable where pid='" + DDL26.SelectedValue.ToString() + "'", con);

           //String price = cmd1.ExecuteScalar().ToString();
            pricet = Convert.ToInt32(cmd1.ExecuteScalar());
            Session.Add("money",pricet);
        
            Button1.Text = "PAY ₹ "+pricet;
            Button2.Text = "PAY ₹ " + pricet;
           
            con.Close();
        }

        protected void fname_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select dummystudenttable.studentname,dummystudenttable.studentid from dummystudenttable join sport_team_list on sport_team_list.studentid=dummystudenttable.studentid", con);
            SqlDataReader sda = cmd1.ExecuteReader();
            if (sda.HasRows)
            {
                while (sda.Read())
                {
                    if (fname.Text == sda["studentname"].ToString())
                    {
                        fname.BorderColor = Color.Green;
                        divtag.Visible = true;
                        Session.RemoveAll();
                        Session.Add("id", sda["studentid"].ToString());
                      
                        break;
                    }
                    else
                    {
                        fname.BorderColor = Color.Red;
                    }
                }
            }
            else
            {
                fname.BorderColor = Color.Red;
            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into paymenttable values(@bf,@amt,@bfid,@item) ", con);
            cmd.Parameters.AddWithValue("bf", fname.Text);
            cmd.Parameters.AddWithValue("bfid", Session["id"].ToString());
            cmd.Parameters.AddWithValue("amt", Session["money"].ToString());
            cmd.Parameters.AddWithValue("item", DDL26.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SPORT Kit!', 'purchase of " + DDL26.SelectedItem.ToString() + " worth " + Session["money"].ToString() + " from CSMS successful', 'success');", true);
            Session.RemoveAll();
            
            Response.Redirect("index.aspx");
        }
    }
}