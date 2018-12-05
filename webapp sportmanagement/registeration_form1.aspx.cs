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
using System.Configuration;


namespace webapp_sportmanagement
{
    public partial class registeration_form1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DANIEL\\source\\repos\\Sport Mangement\\webapp sportmanagement\\App_Data\\newdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            }

        }
        //check if rollno exist for individual player
        protected void Textbox11_onTextchanged(object sender, EventArgs e)
        {
            try
            {

                String roll = TextBox11.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from dummystudenttable where studentid=@roll", con);
                cmd.Parameters.AddWithValue("@roll", roll);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr["studentname"].ToString();
                        TextBox3.Text = dr["dob"].ToString();
                        TextBox4.Text = dr["mobile"].ToString();
                        TextBox5.Text = dr["courseid"].ToString();


                        TextBox2.Enabled = false;
                        TextBox3.Enabled = false;
                        TextBox4.Enabled = false;
                        TextBox5.Enabled = false;


                    }
                }
                else
                {
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";

                    TextBox2.Enabled = true;
                    TextBox4.Enabled = true;
                    TextBox3.Enabled = true;
                    TextBox5.Enabled = true;



                }

                con.Close();

            }
            catch (Exception ex) { Response.Write(ex); }

        }
        protected void back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String tid = DDL1.SelectedValue.ToString();
            String roll = TextBox11.Text;
            int count = 0;
            foreach (ListItem list in CheckBoxList1.Items)
            {
                if (list.Selected == true)
                {
                    count++;
                    con.Open();
                    SqlDataAdapter sd = new SqlDataAdapter("select studentid from scoreboardtable", con);
                    DataSet ds = new DataSet();
                    sd.Fill(ds, "id");
                    List<string> stid = new List<string>();
                    foreach (DataRow row in ds.Tables["id"].Rows)
                    {
                        stid.Add(row["studentid"].ToString());

                    }
                    con.Close();
                    Boolean check = stid.Contains(TextBox11.Text);
                    if (check == false)
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand("insert into scoreboardtable (tid,studentid,sid) values (@tid,@studentid,@sid)", con);
                            cmd2.Parameters.AddWithValue("@tid", tid);
                            cmd2.Parameters.AddWithValue("@studentid", roll);
                            cmd2.Parameters.AddWithValue("@sid", list.Value);
                            cmd2.ExecuteNonQuery();
                            con.Close();
                            
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SUCCESS!', 'Succesfully registered');", true);
                        }
                        catch (Exception ew) { Response.Write(ew); }
                    }
                    else
                    {
                        
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!', 'Already exist for an individual event');", true);
                    }
                       
                }
               
               
            }
            if (count == 0)
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Please select a sport event to continue');", true);
            }
        }
        //selecting sport for dropdown for individual event
        protected void DDL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectCommand = "SELECT sportid, sportname FROM sporteventtable JOIN tournament_sport_table on sporteventtable.sportid=tournament_sport_table.sid WHERE sporteventtable.max_players=1 and tournament_sport_table.tid='" + DDL1.SelectedValue.ToString() + "'";
            // SqlDataSource1.SelectParameters.Add("td", DDL1.SelectedValue.ToString());

        }
        //individual sport view
        protected void individual_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            con.Open();
            SqlCommand cmd = new SqlCommand("select tournamentid,tname from addtournamenttable", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DDL1.DataSource = dr;
            DDL1.DataTextField = "tname";
            DDL1.DataValueField = "tournamentid";
            DDL1.DataBind();
            con.Close();
            DDL1.Items.Insert(0, new ListItem("--Select tournament--", "0"));
        }
        //group sports view
        protected void Group_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            MultiView2.ActiveViewIndex = 0;
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select courseid,coursename from coursetable", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            Deptlist.DataSource = dr1;
            Deptlist.DataTextField = "coursename";
            Deptlist.DataValueField = "courseid";
            Deptlist.DataBind();
            con.Close();
            Deptlist.Items.Insert(0, new ListItem("--Select department--", "0"));





        }

        //selecting dept
        protected void Deptlist_SelectedIndexChanged(object sender, EventArgs e)
        {

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            con.Open();
            SqlCommand cmd = new SqlCommand("select tournamentid,tname from addtournamenttable", con);
            SqlDataReader dr = cmd.ExecuteReader();
            tourlist.DataSource = dr;
            tourlist.DataTextField = "tname";
            tourlist.DataValueField = "tournamentid";
            tourlist.DataBind();
            con.Close();
            tourlist.Items.Insert(0, new ListItem("--Select tournament--", "0"));
            tourlist.Enabled = true;

          

        }
        //selecting tournament for group sport
        protected void tourlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select sid,sportname,max_players from tournament_sport_table join sporteventtable on sporteventtable.sportid = tournament_sport_table.sid and sporteventtable.max_players > 1  where tournament_sport_table.tid=@tid", con);
            cmd1.Parameters.AddWithValue("@tid", tourlist.SelectedValue.ToString());
            SqlDataReader dr1 = cmd1.ExecuteReader();
            toursportlist.DataSource = dr1;
            toursportlist.DataTextField = "sportname";
            toursportlist.DataValueField = "sid";
            toursportlist.DataBind();
            con.Close();
            toursportlist.Items.Insert(0, new ListItem("--Select sport--", "0"));
            toursportlist.Enabled = true;
        }
        //selecting sport for group sport
        protected void toursportlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            
            

            if (checkidexist() == false)
            {
                switch (toursportlist.SelectedItem.ToString())
                {
                    case "FOOTBALL":
                        MultiView2.ActiveViewIndex = 1;



                        break;
                    case "CRICKET":
                        MultiView2.ActiveViewIndex = 2;
                        break;
                    case "BASKETBALL":
                        MultiView2.ActiveViewIndex = 3;
                        break;
                    case "VOLLEYBALL":
                        MultiView2.ActiveViewIndex = 4;
                        break;
                    case "THROWBALL":
                        MultiView2.ActiveViewIndex = 5;
                        break;
                    case "HOCKEY":
                        MultiView2.ActiveViewIndex = 6;
                        break;

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','" + Deptlist.SelectedItem.ToString() + " has already been registered. please choose another DEPT');", true);
                tourlist.ClearSelection();
                Deptlist.ClearSelection();
                toursportlist.ClearSelection();
                tourlist.Enabled = false;
                toursportlist.Enabled = false;
            }
        }



        //footbal grp event starts....
        protected void grpbtnbackp1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        //checking if rollno exist for group registeristion
        protected void p1_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@roll", p1.Text);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p1.BorderColor = Color.Green;
            }
            else
            {
                p1.BorderColor = Color.Red;

            }
        }
        protected void p2_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p2.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p2.BorderColor = Color.Green;
            }
            else
            {
                p2.BorderColor = Color.Red;

            }
        }
        protected void p3_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p3.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p3.BorderColor = Color.Green;
            }
            else
            {
                p3.BorderColor = Color.Red;
            }
        }
        protected void p4_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p4.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p4.BorderColor = Color.Green;
            }
            else
            {
                p4.BorderColor = Color.Red;
            }
        }
        protected void p5_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p5.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p5.BorderColor = Color.Green;
            }
            else
            {
                p5.BorderColor = Color.Red;
            }
        }
        protected void p6_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p6.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p6.BorderColor = Color.Green;
            }
            else
            {
                p6.BorderColor = Color.Red;
            }
        }
        protected void p7_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p7.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p7.BorderColor = Color.Green;
            }
            else
            {
                p7.BorderColor = Color.Red;
            }
        }
        protected void p8_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p8.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p8.BorderColor = Color.Green;
            }
            else
            {
                p8.BorderColor = Color.Red;
            }
        }
        protected void p9_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p9.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p9.BorderColor = Color.Green;
            }
            else
            {
                p9.BorderColor = Color.Red;
            }
        }
        protected void p10_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p10.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p10.BorderColor = Color.Green;
            }
            else
            {
                p10.BorderColor = Color.Red;
            }
        }
        protected void p11_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p11.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p11.BorderColor = Color.Green;
            }
            else
            {
                p11.BorderColor = Color.Red;
            }
        }
        protected void p12_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p12.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p12.BorderColor = Color.Green;
            }
            else
            {
                p12.BorderColor = Color.Red;
            }
        }
        protected void p13_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p13.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p13.BorderColor = Color.Green;
            }
            else
            {
                p13.BorderColor = Color.Red;
            }
        }
        protected void p14_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", p14.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p14.BorderColor = Color.Green;
            }
            else
            {
                p14.BorderColor = Color.Red;
            }
        }
        protected void p15_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll", con);
            cmd.Parameters.AddWithValue("@roll", p15.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                p15.BorderColor = Color.Green;
            }
            else
            {
                p15.BorderColor = Color.Red;
            }
        }
        //grp sport confirmation
        protected void grpbtnconfirmp1_Click(object sender, EventArgs e)
        {
            if ((p1.BorderColor == Color.Green) && (p2.BorderColor == Color.Green) && (p3.BorderColor == Color.Green) && (p4.BorderColor == Color.Green) && (p5.BorderColor == Color.Green) && (p6.BorderColor == Color.Green) && (p7.BorderColor == Color.Green) && (p8.BorderColor == Color.Green) && (p9.BorderColor == Color.Green) && (p10.BorderColor == Color.Green) && (p11.BorderColor == Color.Green) && (p12.BorderColor == Color.Green) && (p13.BorderColor == Color.Green) && (p14.BorderColor == Color.Green) && (p15.BorderColor == Color.Green))
            {
                //check p1 unique
                if ((p1.Text != p2.Text) && (p1.Text != p3.Text) && (p1.Text != p4.Text) && (p1.Text != p5.Text) && (p1.Text != p6.Text) && (p1.Text != p7.Text) && (p1.Text != p8.Text) && (p1.Text != p9.Text) && (p1.Text != p10.Text) && (p1.Text != p11.Text) && (p1.Text != p12.Text) && (p1.Text != p13.Text) && (p1.Text != p14.Text) && (p1.Text != p15.Text))
                {
                    //check p2 unique
                    if ((p2.Text != p3.Text) && (p2.Text != p4.Text) && (p2.Text != p5.Text) && (p2.Text != p6.Text) && (p2.Text != p7.Text) && (p2.Text != p8.Text) && (p2.Text != p9.Text) && (p2.Text != p10.Text) && (p2.Text != p11.Text) && (p2.Text != p12.Text) && (p2.Text != p13.Text) && (p2.Text != p14.Text) && (p2.Text != p15.Text))
                    {
                        //check p3 unique
                        if ((p3.Text != p4.Text) && (p3.Text != p5.Text) && (p3.Text != p6.Text) && (p3.Text != p7.Text) && (p3.Text != p8.Text) && (p3.Text != p9.Text) && (p3.Text != p10.Text) && (p3.Text != p11.Text) && (p3.Text != p12.Text) && (p3.Text != p13.Text) && (p3.Text != p14.Text) && (p3.Text != p15.Text))
                        {
                            //check p4 unique
                            if ((p4.Text != p5.Text) && (p4.Text != p6.Text) && (p4.Text != p7.Text) && (p4.Text != p8.Text) && (p4.Text != p9.Text) && (p4.Text != p10.Text) && (p4.Text != p11.Text) && (p4.Text != p12.Text) && (p4.Text != p13.Text) && (p4.Text != p14.Text) && (p4.Text != p15.Text))
                            {
                                //check p5 unique
                                if ((p5.Text != p6.Text) && (p5.Text != p7.Text) && (p5.Text != p8.Text) && (p5.Text != p9.Text) && (p5.Text != p10.Text) && (p5.Text != p11.Text) && (p5.Text != p12.Text) && (p5.Text != p13.Text) && (p5.Text != p14.Text) && (p5.Text != p15.Text))
                                {
                                    //check p6 unique
                                    if ((p6.Text != p7.Text) && (p6.Text != p8.Text) && (p6.Text != p9.Text) && (p6.Text != p10.Text) && (p6.Text != p11.Text) && (p6.Text != p12.Text) && (p6.Text != p13.Text) && (p6.Text != p14.Text) && (p6.Text != p15.Text))
                                    {
                                        //check p7 unique
                                        if ((p7.Text != p8.Text) && (p7.Text != p9.Text) && (p7.Text != p10.Text) && (p7.Text != p11.Text) && (p7.Text != p12.Text) && (p7.Text != p13.Text) && (p7.Text != p14.Text) && (p7.Text != p15.Text))
                                        {
                                            //check p8 unique
                                            if ((p8.Text != p9.Text) && (p8.Text != p10.Text) && (p8.Text != p11.Text) && (p8.Text != p12.Text) && (p8.Text != p13.Text) && (p8.Text != p14.Text) && (p8.Text != p15.Text))
                                            {
                                                //check p9 unique
                                                if ((p9.Text != p10.Text) && (p9.Text != p11.Text) && (p9.Text != p12.Text) && (p9.Text != p13.Text) && (p9.Text != p14.Text) && (p9.Text != p15.Text))
                                                {
                                                    //check p10 unique
                                                    if ((p10.Text != p11.Text) && (p10.Text != p12.Text) && (p10.Text != p13.Text) && (p10.Text != p14.Text) && (p10.Text != p15.Text))
                                                    {
                                                        //check p11 unique
                                                        if ((p11.Text != p12.Text) && (p11.Text != p13.Text) && (p11.Text != p14.Text) && (p11.Text != p15.Text))
                                                        {
                                                            //check p12 unique
                                                            if ((p12.Text != p13.Text) && (p12.Text != p14.Text) && (p12.Text != p15.Text))
                                                            {
                                                                //check p13 unique
                                                                if ((p13.Text != p14.Text) && (p13.Text != p15.Text))
                                                                {
                                                                    //check p14 unique
                                                                    if ((p14.Text != p15.Text))
                                                                    {
                                                                       
                                                                        int token;
                                                                        //enter into db
                                                                        con.Open();
                                                                        SqlDataAdapter sd = new SqlDataAdapter("select teamname from groupsportdetail", con);
                                                                        DataSet ds = new DataSet();
                                                                        sd.Fill(ds, "TNAME");
                                                                        List<string> tname = new List<string>();
                                                                        foreach (DataRow row in ds.Tables["TNAME"].Rows)
                                                                        {
                                                                            tname.Add(row["teamname"].ToString());

                                                                        }
                                                                        con.Close();
                                                                       
                                                                        Boolean check = tname.Contains(teamname.Text);
                                                                        if (check == false)
                                                                        {
                                                                            con.Close();
                                                                            con.Open();
                                                                            SqlCommand cmd2 = new SqlCommand("insert into groupsportdetail (teamname,sportid,courseid,tournamentid) values (@teamname,@sportid,@courseid,@tournamentid)", con);
                                                                            cmd2.Parameters.AddWithValue("@teamname", teamname.Text);
                                                                            cmd2.Parameters.AddWithValue("@sportid", toursportlist.SelectedValue.ToString());
                                                                            cmd2.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
                                                                            cmd2.Parameters.AddWithValue("@tournamentid", tourlist.SelectedValue.ToString());
                                                                            cmd2.ExecuteNonQuery();
                                                                            con.Close();

                                                                            con.Open();
                                                                            SqlCommand cmd = new SqlCommand("select token from groupsportdetail where teamname=@teamname ", con);
                                                                            cmd.Parameters.AddWithValue("@teamname", teamname.Text);
                                                                            token = (int)cmd.ExecuteScalar();
                                                                            con.Close();
                                                                            string[] value = { p1.Text, p2.Text, p3.Text, p4.Text, p5.Text, p6.Text, p7.Text, p8.Text, p9.Text, p10.Text, p11.Text, p12.Text, p13.Text, p14.Text, p15.Text };
                                                                            for (int i = 0; i < 15; i++)
                                                                            {
                                                                                con.Open();
                                                                                SqlCommand cmd1 = new SqlCommand("insert into groupsporteventstudentlist (token,studentid) values (@token,@studentid)", con);
                                                                                cmd1.Parameters.AddWithValue("@token", token);
                                                                                cmd1.Parameters.AddWithValue("@studentid", value[i]);
                                                                                cmd1.ExecuteNonQuery();
                                                                                con.Close();
                                                                            }
                                                                            
                                                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SUCCESS!', 'Succesfully registered');", true);

                                                                        }
                                                                        else
                                                                        {
                                                                            
                                                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','team name already taken');", true);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        
                                                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                    }
                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                }
            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. doesnt exist...');", true);
            }



        }
        
        //end of football grp event


        //start cricket.....
       
        protected void grpbtnbackpc1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        //checking if rollno exist for group registeristion
        protected void pc1_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@roll", pc1.Text);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc1.BorderColor = Color.Green;
            }
            else
            {
                pc1.BorderColor = Color.Red;

            }
        }
        protected void pc2_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc2.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc2.BorderColor = Color.Green;
            }
            else
            {
                pc2.BorderColor = Color.Red;

            }
        }
        protected void pc3_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc3.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc3.BorderColor = Color.Green;
            }
            else
            {
                pc3.BorderColor = Color.Red;
            }
        }
        protected void pc4_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc4.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc4.BorderColor = Color.Green;
            }
            else
            {
                pc4.BorderColor = Color.Red;
            }
        }
        protected void pc5_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc5.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc5.BorderColor = Color.Green;
            }
            else
            {
                pc5.BorderColor = Color.Red;
            }
        }
        protected void pc6_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc6.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc6.BorderColor = Color.Green;
            }
            else
            {
                pc6.BorderColor = Color.Red;
            }
        }
        protected void pc7_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc7.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc7.BorderColor = Color.Green;
            }
            else
            {
                pc7.BorderColor = Color.Red;
            }
        }
        protected void pc8_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc8.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc8.BorderColor = Color.Green;
            }
            else
            {
                pc8.BorderColor = Color.Red;
            }
        }
        protected void pc9_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc9.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc9.BorderColor = Color.Green;
            }
            else
            {
                pc9.BorderColor = Color.Red;
            }
        }
        protected void pc10_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc10.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc10.BorderColor = Color.Green;
            }
            else
            {
                pc10.BorderColor = Color.Red;
            }
        }
        protected void pc11_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc11.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc11.BorderColor = Color.Green;
            }
            else
            {
                pc11.BorderColor = Color.Red;
            }
        }
        protected void pc12_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc12.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc12.BorderColor = Color.Green;
            }
            else
            {
                pc12.BorderColor = Color.Red;
            }
        }
        protected void pc13_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc13.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc13.BorderColor = Color.Green;
            }
            else
            {
                pc13.BorderColor = Color.Red;
            }
        }
        protected void pc14_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pc14.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc14.BorderColor = Color.Green;
            }
            else
            {
                pc14.BorderColor = Color.Red;
            }
        }
        protected void pc15_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll", con);
            cmd.Parameters.AddWithValue("@roll", pc15.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pc15.BorderColor = Color.Green;
            }
            else
            {
                pc15.BorderColor = Color.Red;
            }
        }
        //grp sport confirmation
        protected void grpbtnconfirmpc1_Click(object sender, EventArgs e)
        {
            if ((pc1.BorderColor == Color.Green) && (pc2.BorderColor == Color.Green) && (pc3.BorderColor == Color.Green) && (pc4.BorderColor == Color.Green) && (pc5.BorderColor == Color.Green) && (pc6.BorderColor == Color.Green) && (pc7.BorderColor == Color.Green) && (pc8.BorderColor == Color.Green) && (pc9.BorderColor == Color.Green) && (pc10.BorderColor == Color.Green) && (pc11.BorderColor == Color.Green) && (pc12.BorderColor == Color.Green) && (pc13.BorderColor == Color.Green) && (pc14.BorderColor == Color.Green) && (pc15.BorderColor == Color.Green))
            {
                //check p1 unique
                if ((pc1.Text != pc2.Text) && (pc1.Text != pc3.Text) && (pc1.Text != pc4.Text) && (pc1.Text != pc5.Text) && (pc1.Text != pc6.Text) && (pc1.Text != pc7.Text) && (pc1.Text != pc8.Text) && (pc1.Text != pc9.Text) && (pc1.Text != pc10.Text) && (pc1.Text != pc11.Text) && (pc1.Text != pc12.Text) && (pc1.Text != pc13.Text) && (pc1.Text != pc14.Text) && (pc1.Text != pc15.Text))
                {
                    //check p2 unique
                    if ((pc2.Text != pc3.Text) && (pc2.Text != pc4.Text) && (pc2.Text != pc5.Text) && (pc2.Text != pc6.Text) && (pc2.Text != pc7.Text) && (pc2.Text != pc8.Text) && (pc2.Text != pc9.Text) && (pc2.Text != pc10.Text) && (pc2.Text != pc11.Text) && (pc2.Text != pc12.Text) && (pc2.Text != pc13.Text) && (pc2.Text != pc14.Text) && (pc2.Text != pc15.Text))
                    {
                        //check p3 unique
                        if ((pc3.Text != pc4.Text) && (pc3.Text != pc5.Text) && (pc3.Text != pc6.Text) && (pc3.Text != pc7.Text) && (pc3.Text != pc8.Text) && (pc3.Text != pc9.Text) && (pc3.Text != pc10.Text) && (pc3.Text != pc11.Text) && (pc3.Text != pc12.Text) && (pc3.Text != pc13.Text) && (pc3.Text != pc14.Text) && (pc3.Text != pc15.Text))
                        {
                            //check p4 unique
                            if ((pc4.Text != pc5.Text) && (pc4.Text != pc6.Text) && (pc4.Text != pc7.Text) && (pc4.Text != pc8.Text) && (pc4.Text != pc9.Text) && (pc4.Text != pc10.Text) && (pc4.Text != pc11.Text) && (pc4.Text != pc12.Text) && (pc4.Text != pc13.Text) && (pc4.Text != pc14.Text) && (pc4.Text != pc15.Text))
                            {
                                //check p5 unique
                                if ((pc5.Text != pc6.Text) && (pc5.Text != pc7.Text) && (pc5.Text != pc8.Text) && (pc5.Text != pc9.Text) && (pc5.Text != pc10.Text) && (pc5.Text != pc11.Text) && (pc5.Text != pc12.Text) && (pc5.Text != pc13.Text) && (pc5.Text != pc14.Text) && (pc5.Text != pc15.Text))
                                {
                                    //check p6 unique
                                    if ((pc6.Text != pc7.Text) && (pc6.Text != pc8.Text) && (pc6.Text != pc9.Text) && (pc6.Text != pc10.Text) && (pc6.Text != pc11.Text) && (pc6.Text != pc12.Text) && (pc6.Text != pc13.Text) && (pc6.Text != pc14.Text) && (pc6.Text != pc15.Text))
                                    {
                                        //check p7 unique
                                        if ((pc7.Text != pc8.Text) && (pc7.Text != pc9.Text) && (pc7.Text != pc10.Text) && (pc7.Text != pc11.Text) && (pc7.Text != pc12.Text) && (pc7.Text != pc13.Text) && (pc7.Text != pc14.Text) && (pc7.Text != pc15.Text))
                                        {
                                            //check p8 unique
                                            if ((pc8.Text != pc9.Text) && (pc8.Text != pc10.Text) && (pc8.Text != pc11.Text) && (pc8.Text != pc12.Text) && (pc8.Text != pc13.Text) && (pc8.Text != pc14.Text) && (pc8.Text != pc15.Text))
                                            {
                                                //check p9 unique
                                                if ((pc9.Text != pc10.Text) && (pc9.Text != pc11.Text) && (pc9.Text != pc12.Text) && (pc9.Text != pc13.Text) && (pc9.Text != pc14.Text) && (pc9.Text != pc15.Text))
                                                {
                                                    //check p10 unique
                                                    if ((pc10.Text != pc11.Text) && (pc10.Text != pc12.Text) && (pc10.Text != pc13.Text) && (pc10.Text != pc14.Text) && (pc10.Text != pc15.Text))
                                                    {
                                                        //check p11 unique
                                                        if ((pc11.Text != pc12.Text) && (pc11.Text != pc13.Text) && (pc11.Text != pc14.Text) && (pc11.Text != pc15.Text))
                                                        {
                                                            //check p12 unique
                                                            if ((pc12.Text != pc13.Text) && (pc12.Text != pc14.Text) && (pc12.Text != pc15.Text))
                                                            {
                                                                //check p13 unique
                                                                if ((pc13.Text != pc14.Text) && (pc13.Text != pc15.Text))
                                                                {
                                                                    //check p14 unique
                                                                    if ((pc14.Text != pc15.Text))
                                                                    {
                                                                        int token;
                                                                        //enter into db
                                                                        con.Open();
                                                                        SqlDataAdapter sd = new SqlDataAdapter("select teamname from groupsportdetail", con);
                                                                        DataSet ds = new DataSet();
                                                                        sd.Fill(ds, "TNAME");
                                                                        List<string> tname = new List<string>();
                                                                        foreach (DataRow row in ds.Tables["TNAME"].Rows)
                                                                        {
                                                                            tname.Add(row["teamname"].ToString());

                                                                        }
                                                                        con.Close();
                                                                        Boolean check = tname.Contains(teamname.Text);
                                                                        if (check == false)
                                                                        {
                                                                            con.Open();
                                                                            SqlCommand cmd2 = new SqlCommand("insert into groupsportdetail (teamname,sportid,courseid,tournamentid) values (@teamname,@sportid,@courseid,@tournamentid)", con);
                                                                            cmd2.Parameters.AddWithValue("@teamname", teamname.Text);
                                                                            cmd2.Parameters.AddWithValue("@sportid", toursportlist.SelectedValue.ToString());
                                                                            cmd2.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
                                                                            cmd2.Parameters.AddWithValue("@tournamentid", tourlist.SelectedValue.ToString());
                                                                            cmd2.ExecuteNonQuery();
                                                                            con.Close();

                                                                            con.Open();
                                                                            SqlCommand cmd = new SqlCommand("select token from groupsportdetail where teamname=@teamname ", con);
                                                                            cmd.Parameters.AddWithValue("@teamname", teamname.Text);
                                                                            token = (int)cmd.ExecuteScalar();
                                                                            con.Close();
                                                                            string[] value = { pc1.Text, pc2.Text, pc3.Text, pc4.Text, pc5.Text, pc6.Text, pc7.Text, pc8.Text, pc9.Text, pc10.Text, pc11.Text, pc12.Text, pc13.Text, pc14.Text, pc15.Text };
                                                                            for (int i = 0; i < 15; i++)
                                                                            {
                                                                                con.Open();
                                                                                SqlCommand cmd1 = new SqlCommand("insert into groupsporteventstudentlist (token,studentid) values (@token,@studentid)", con);
                                                                                cmd1.Parameters.AddWithValue("@token", token);
                                                                                cmd1.Parameters.AddWithValue("@studentid", value[i]);
                                                                                cmd1.ExecuteNonQuery();
                                                                                con.Close();
                                                                            }
                                                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully registered');", true);
                                                                        }
                                                                        else
                                                                        {
                                                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('team name already taken');", true);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                                    }
                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. should be unique...');", true);
                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Roll no. doesnt exist...');", true);
            }

        }
        //end of cricket grp event



        //start basketball.....
        protected void grpbtnbackpb1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        //checking if rollno exist for group registeristion
        protected void pb1_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@roll", pb1.Text);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb1.BorderColor = Color.Green;
            }
            else
            {
                pb1.BorderColor = Color.Red;

            }
        }
        protected void pb2_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb2.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb2.BorderColor = Color.Green;
            }
            else
            {
                pb2.BorderColor = Color.Red;

            }
        }
        protected void pb3_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb3.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb3.BorderColor = Color.Green;
            }
            else
            {
                pb3.BorderColor = Color.Red;
            }
        }
        protected void pb4_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb4.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb4.BorderColor = Color.Green;
            }
            else
            {
                pb4.BorderColor = Color.Red;
            }
        }
        protected void pb5_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb5.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb5.BorderColor = Color.Green;
            }
            else
            {
                pb5.BorderColor = Color.Red;
            }
        }
        protected void pb6_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb6.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb6.BorderColor = Color.Green;
            }
            else
            {
                pb6.BorderColor = Color.Red;
            }
        }
        protected void pb7_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb7.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb7.BorderColor = Color.Green;
            }
            else
            {
                pb7.BorderColor = Color.Red;
            }
        }
        protected void pb8_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb8.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb8.BorderColor = Color.Green;
            }
            else
            {
                pb8.BorderColor = Color.Red;
            }
        }
        protected void pb9_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb9.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb9.BorderColor = Color.Green;
            }
            else
            {
                pb9.BorderColor = Color.Red;
            }
        }
        protected void pb10_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pb10.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pb10.BorderColor = Color.Green;
            }
            else
            {
                pb10.BorderColor = Color.Red;
            }
        }
    
        //grp sport confirmation
        protected void grpbtnconfirmpb1_Click(object sender, EventArgs e)
        {
            if ((pb1.BorderColor == Color.Green) && (pb2.BorderColor == Color.Green) && (pb3.BorderColor == Color.Green) && (pb4.BorderColor == Color.Green) && (pb5.BorderColor == Color.Green) && (pb6.BorderColor == Color.Green) && (pb7.BorderColor == Color.Green) && (pb8.BorderColor == Color.Green) && (pb9.BorderColor == Color.Green) && (pb10.BorderColor == Color.Green) )
            {
                //check p1 unique
                if ((pb1.Text != pb2.Text) && (pb1.Text != pb3.Text) && (pb1.Text != pb4.Text) && (pb1.Text != pb5.Text) && (pb1.Text != pb6.Text) && (pb1.Text != pb7.Text) && (pb1.Text != pb8.Text) && (pb1.Text != pb9.Text) && (pb1.Text != pb10.Text))
                {
                    //check p2 unique
                    if ((pb2.Text != pb3.Text) && (pb2.Text != pb4.Text) && (pb2.Text != pb5.Text) && (pb2.Text != pb6.Text) && (pb2.Text != pb7.Text) && (pb2.Text != pb8.Text) && (pb2.Text != pb9.Text) && (pb2.Text != pb10.Text))
                    {
                        //check p3 unique
                        if ((pb3.Text != pb4.Text) && (pb3.Text != pb5.Text) && (pb3.Text != pb6.Text) && (pb3.Text != pb7.Text) && (pb3.Text != pb8.Text) && (pb3.Text != pb9.Text) && (pb3.Text != pb10.Text))
                        {
                            //check p4 unique
                            if ((pb4.Text != pb5.Text) && (pb4.Text != pb6.Text) && (pb4.Text != pb7.Text) && (pb4.Text != pb8.Text) && (pb4.Text != pb9.Text) && (pb4.Text != pb10.Text))
                            {
                                //check p5 unique
                                if ((pb5.Text != pb6.Text) && (pb5.Text != pb7.Text) && (pb5.Text != pb8.Text) && (pb5.Text != pb9.Text) && (pb5.Text != pb10.Text))
                                {
                                    //check p6 unique
                                    if ((pb6.Text != pb7.Text) && (pb6.Text != pb8.Text) && (pb6.Text != pb9.Text) && (pb6.Text != pb10.Text))
                                    {
                                        //check p7 unique
                                        if ((pb7.Text != pb8.Text) && (pb7.Text != pb9.Text) && (pb7.Text != pb10.Text))
                                        {
                                            //check p8 unique
                                            if ((pb8.Text != pb9.Text) && (pb8.Text != pb10.Text))
                                            {
                                                //check p9 unique
                                                if ((pb9.Text != pb10.Text))
                                                {
                                                   
                                                    int token;
                                                    //enter into db
                                                    con.Open();
                                                    SqlDataAdapter sd = new SqlDataAdapter("select teamname from groupsportdetail", con);
                                                    DataSet ds = new DataSet();
                                                    sd.Fill(ds, "TNAME");
                                                    List<string> tname = new List<string>();
                                                    foreach (DataRow row in ds.Tables["TNAME"].Rows)
                                                    {
                                                        tname.Add(row["teamname"].ToString());

                                                    }
                                                    con.Close();
                                                    Boolean check = tname.Contains(teamname.Text);
                                                    if (check == false)
                                                    {
                                                        con.Open();
                                                        SqlCommand cmd2 = new SqlCommand("insert into groupsportdetail (teamname,sportid,courseid,tournamentid) values (@teamname,@sportid,@courseid,@tournamentid)", con);
                                                        cmd2.Parameters.AddWithValue("@teamname", teamname.Text);
                                                        cmd2.Parameters.AddWithValue("@sportid", toursportlist.SelectedValue.ToString());
                                                        cmd2.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
                                                        cmd2.Parameters.AddWithValue("@tournamentid", tourlist.SelectedValue.ToString());
                                                        cmd2.ExecuteNonQuery();
                                                        con.Close();

                                                        con.Open();
                                                        SqlCommand cmd = new SqlCommand("select token from groupsportdetail where teamname=@teamname ", con);
                                                        cmd.Parameters.AddWithValue("@teamname", teamname.Text);
                                                        token = (int)cmd.ExecuteScalar();
                                                        con.Close();
                                                        string[] value = { pb1.Text, pb2.Text, pb3.Text, pb4.Text, pb5.Text, pb6.Text, pb7.Text, pb8.Text, pb9.Text, pb10.Text };
                                                        for (int i = 0; i < 10; i++)
                                                        {
                                                            con.Open();
                                                            SqlCommand cmd1 = new SqlCommand("insert into groupsporteventstudentlist (token,studentid) values (@token,@studentid)", con);
                                                            cmd1.Parameters.AddWithValue("@token", token);
                                                            cmd1.Parameters.AddWithValue("@studentid", value[i]);
                                                            cmd1.ExecuteNonQuery();
                                                            con.Close();
                                                        }
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SUCCESS!', 'Succesfully registered');", true);

                                                    }
                                                    else
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','team name already taken');", true);
                                                    }
                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                }
                                                    
                                                   
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                            }

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                    }

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                }

            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. doesnt exist...');", true);
            }

        }
        //end basketball


        //start volleyball....
        protected void grpbtnbackpv1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        //checking if rollno exist for group registeristion
        protected void pv1_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@roll", pv1.Text);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv1.BorderColor = Color.Green;
            }
            else
            {
                pv1.BorderColor = Color.Red;

            }
        }
        protected void pv2_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv2.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv2.BorderColor = Color.Green;
            }
            else
            {
                pv2.BorderColor = Color.Red;

            }
        }
        protected void pv3_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv3.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv3.BorderColor = Color.Green;
            }
            else
            {
                pv3.BorderColor = Color.Red;
            }
        }
        protected void pv4_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv4.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv4.BorderColor = Color.Green;
            }
            else
            {
                pv4.BorderColor = Color.Red;
            }
        }
        protected void pv5_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv5.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv5.BorderColor = Color.Green;
            }
            else
            {
                pv5.BorderColor = Color.Red;
            }
        }
        protected void pv6_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv6.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv6.BorderColor = Color.Green;
            }
            else
            {
                pv6.BorderColor = Color.Red;
            }
        }
        protected void pv7_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv7.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv7.BorderColor = Color.Green;
            }
            else
            {
                pv7.BorderColor = Color.Red;
            }
        }
        protected void pv8_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv8.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv8.BorderColor = Color.Green;
            }
            else
            {
                pv8.BorderColor = Color.Red;
            }
        }
        protected void pv9_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv9.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv9.BorderColor = Color.Green;
            }
            else
            {
                pv9.BorderColor = Color.Red;
            }
        }
        protected void pv10_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pv10.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pv10.BorderColor = Color.Green;
            }
            else
            {
                pv10.BorderColor = Color.Red;
            }
        }

        //grp sport confirmation
        protected void grpbtnconfirmpv1_Click(object sender, EventArgs e)
        {
            if ((pb1.BorderColor == Color.Green) && (pb2.BorderColor == Color.Green) && (pb3.BorderColor == Color.Green) && (pb4.BorderColor == Color.Green) && (pb5.BorderColor == Color.Green) && (pb6.BorderColor == Color.Green) && (pb7.BorderColor == Color.Green) && (pb8.BorderColor == Color.Green) && (pb9.BorderColor == Color.Green) && (pb10.BorderColor == Color.Green))
            {
                //check p1 unique
                if ((pv1.Text != pv2.Text) && (pv1.Text != pv3.Text) && (pv1.Text != pv4.Text) && (pv1.Text != pv5.Text) && (pv1.Text != pv6.Text) && (pv1.Text != pv7.Text) && (pv1.Text != pv8.Text) && (pv1.Text != pv9.Text) && (pv1.Text != pv10.Text))
                {
                    //check p2 unique
                    if ((pv2.Text != pv3.Text) && (pv2.Text != pv4.Text) && (pv2.Text != pv5.Text) && (pv2.Text != pv6.Text) && (pv2.Text != pv7.Text) && (pv2.Text != pv8.Text) && (pv2.Text != pv9.Text) && (pv2.Text != pv10.Text))
                    {
                        //check p3 unique
                        if ((pv3.Text != pv4.Text) && (pv3.Text != pv5.Text) && (pv3.Text != pv6.Text) && (pv3.Text != pv7.Text) && (pv3.Text != pv8.Text) && (pb3.Text != pv9.Text) && (pv3.Text != pv10.Text))
                        {
                            //check p4 unique
                            if ((pv4.Text != pv5.Text) && (pv4.Text != pv6.Text) && (pv4.Text != pv7.Text) && (pv4.Text != pv8.Text) && (pv4.Text != pv9.Text) && (pv4.Text != pv10.Text))
                            {
                                //check p5 unique
                                if ((pv5.Text != pv6.Text) && (pv5.Text != pv7.Text) && (pv5.Text != pv8.Text) && (pv5.Text != pv9.Text) && (pv5.Text != pv10.Text))
                                {
                                    //check p6 unique
                                    if ((pv6.Text != pv7.Text) && (pv6.Text != pv8.Text) && (pv6.Text != pv9.Text) && (pv6.Text != pv10.Text))
                                    {
                                        //check p7 unique
                                        if ((pv7.Text != pv8.Text) && (pv7.Text != pv9.Text) && (pv7.Text != pv10.Text))
                                        {
                                            //check p8 unique
                                            if ((pv8.Text != pv9.Text) && (pv8.Text != pv10.Text))
                                            {
                                                //check p9 unique
                                                if ((pv9.Text != pv10.Text))
                                                {

                                                    int token;
                                                    //enter into db
                                                    con.Open();
                                                    SqlDataAdapter sd = new SqlDataAdapter("select teamname from groupsportdetail", con);
                                                    DataSet ds = new DataSet();
                                                    sd.Fill(ds, "TNAME");
                                                    List<string> tname = new List<string>();
                                                    foreach (DataRow row in ds.Tables["TNAME"].Rows)
                                                    {
                                                        tname.Add(row["teamname"].ToString());

                                                    }
                                                    con.Close();
                                                    Boolean check = tname.Contains(teamname.Text);
                                                    if (check == false)
                                                    {
                                                        con.Open();
                                                    SqlCommand cmd2 = new SqlCommand("insert into groupsportdetail (teamname,sportid,courseid,tournamentid) values (@teamname,@sportid,@courseid,@tournamentid)", con);
                                                    cmd2.Parameters.AddWithValue("@teamname", teamname.Text);
                                                    cmd2.Parameters.AddWithValue("@sportid", toursportlist.SelectedValue.ToString());
                                                    cmd2.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
                                                    cmd2.Parameters.AddWithValue("@tournamentid", tourlist.SelectedValue.ToString());
                                                    cmd2.ExecuteNonQuery();
                                                    con.Close();

                                                    con.Open();
                                                    SqlCommand cmd = new SqlCommand("select token from groupsportdetail where teamname=@teamname ", con);
                                                    cmd.Parameters.AddWithValue("@teamname", teamname.Text);
                                                    token = (int)cmd.ExecuteScalar();
                                                    con.Close();
                                                    string[] value = { pv1.Text, pv2.Text, pv3.Text, pv4.Text, pv5.Text, pv6.Text, pv7.Text, pv8.Text, pv9.Text, pv10.Text };
                                                    for (int i = 0; i < 10; i++)
                                                    {
                                                        con.Open();
                                                        SqlCommand cmd1 = new SqlCommand("insert into groupsporteventstudentlist (token,studentid) values (@token,@studentid)", con);
                                                        cmd1.Parameters.AddWithValue("@token", token);
                                                        cmd1.Parameters.AddWithValue("@studentid", value[i]);
                                                        cmd1.ExecuteNonQuery();
                                                        con.Close();
                                                    }
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SUCCESS!', 'Succesfully registered');", true);
                                                    }
                                                else
                                                {
                                                    
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','team name already taken.');", true);
                                                    }
                                            }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                    }
                }
                else
                {
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. doesnt exist...');", true);
            }

        }
        //end volleyball


        // start throwball....
        protected void grpbtnbackpt1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        //checking if rollno exist for group registeristion
        protected void pt1_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@roll", pt1.Text);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt1.BorderColor = Color.Green;
            }
            else
            {
                pt1.BorderColor = Color.Red;

            }
        }
        protected void pt2_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt2.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt2.BorderColor = Color.Green;
            }
            else
            {
                pt2.BorderColor = Color.Red;

            }
        }
        protected void pt3_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt3.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt3.BorderColor = Color.Green;
            }
            else
            {
                pt3.BorderColor = Color.Red;
            }
        }
        protected void pt4_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt4.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt4.BorderColor = Color.Green;
            }
            else
            {
                pt4.BorderColor = Color.Red;
            }
        }
        protected void pt5_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt5.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt5.BorderColor = Color.Green;
            }
            else
            {
                pt5.BorderColor = Color.Red;
            }
        }
        protected void pt6_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt6.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt6.BorderColor = Color.Green;
            }
            else
            {
                pt6.BorderColor = Color.Red;
            }
        }
        protected void pt7_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt7.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt7.BorderColor = Color.Green;
            }
            else
            {
                pt7.BorderColor = Color.Red;
            }
        }
        protected void pt8_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt8.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt8.BorderColor = Color.Green;
            }
            else
            {
                pt8.BorderColor = Color.Red;
            }
        }
        protected void pt9_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt9.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt9.BorderColor = Color.Green;
            }
            else
            {
                pt9.BorderColor = Color.Red;
            }
        }
        protected void pt10_onTextchanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from dummystudenttable where studentid=@roll and courseid=@courseid", con);
            cmd.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@roll", pt10.Text);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                pt10.BorderColor = Color.Green;
            }
            else
            {
                pt10.BorderColor = Color.Red;
            }
        }

        //grp sport confirmation
        protected void grpbtnconfirmpt1_Click(object sender, EventArgs e)
        {
            if ((pb1.BorderColor == Color.Green) && (pb2.BorderColor == Color.Green) && (pb3.BorderColor == Color.Green) && (pb4.BorderColor == Color.Green) && (pb5.BorderColor == Color.Green) && (pb6.BorderColor == Color.Green) && (pb7.BorderColor == Color.Green) && (pb8.BorderColor == Color.Green) && (pb9.BorderColor == Color.Green) && (pb10.BorderColor == Color.Green))
            {
                //check p1 unique
                if ((pt1.Text != pt2.Text) && (pt1.Text != pt3.Text) && (pt1.Text != pt4.Text) && (pt1.Text != pt5.Text) && (pt1.Text != pt6.Text) && (pt1.Text != pt7.Text) && (pt1.Text != pt8.Text) && (pt1.Text != pt9.Text) && (pt1.Text != pt10.Text))
                {
                    //check p2 unique
                    if ((pt2.Text != pt3.Text) && (pt2.Text != pt4.Text) && (pt2.Text != pt5.Text) && (pt2.Text != pt6.Text) && (pt2.Text != pt7.Text) && (pt2.Text != pt8.Text) && (pt2.Text != pt9.Text) && (pt2.Text != pt10.Text))
                    {
                        //check p3 unique
                        if ((pt3.Text != pt4.Text) && (pt3.Text != pt5.Text) && (pt3.Text != pt6.Text) && (pt3.Text != pt7.Text) && (pt3.Text != pt8.Text) && (pt3.Text != pt9.Text) && (pt3.Text != pt10.Text))
                        {
                            //check p4 unique
                            if ((pt4.Text != pt5.Text) && (pt4.Text != pt6.Text) && (pt4.Text != pt7.Text) && (pt4.Text != pt8.Text) && (pt4.Text != pt9.Text) && (pt4.Text != pt10.Text))
                            {
                                //check p5 unique
                                if ((pt5.Text != pt6.Text) && (pt5.Text != pt7.Text) && (pt5.Text != pt8.Text) && (pt5.Text != pt9.Text) && (pt5.Text != pt10.Text))
                                {
                                    //check p6 unique
                                    if ((pt6.Text != pt7.Text) && (pt6.Text != pt8.Text) && (pt6.Text != pt9.Text) && (pt6.Text != pt10.Text))
                                    {
                                        //check p7 unique
                                        if ((pt7.Text != pt8.Text) && (pt7.Text != pt9.Text) && (pt7.Text != pt10.Text))
                                        {
                                            //check p8 unique
                                            if ((pt8.Text != pt9.Text) && (pt8.Text != pt10.Text))
                                            {
                                                //check p9 unique
                                                if ((pt9.Text != pt10.Text))
                                                {

                                                    int token;
                                                    //enter into db
                                                    con.Open();
                                                    SqlDataAdapter sd = new SqlDataAdapter("select teamname from groupsportdetail", con);
                                                    DataSet ds = new DataSet();
                                                    sd.Fill(ds, "TNAME");
                                                    List<string> tname = new List<string>();
                                                    foreach (DataRow row in ds.Tables["TNAME"].Rows)
                                                    {
                                                        tname.Add(row["teamname"].ToString());

                                                    }
                                                    con.Close();
                                                    Boolean check = tname.Contains(teamname.Text);
                                                    if (check == false)
                                                    {
                                                        con.Open();
                                                    SqlCommand cmd2 = new SqlCommand("insert into groupsportdetail (teamname,sportid,courseid,tournamentid) values (@teamname,@sportid,@courseid,@tournamentid)", con);
                                                    cmd2.Parameters.AddWithValue("@teamname", teamname.Text);
                                                    cmd2.Parameters.AddWithValue("@sportid", toursportlist.SelectedValue.ToString());
                                                    cmd2.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
                                                    cmd2.Parameters.AddWithValue("@tournamentid", tourlist.SelectedValue.ToString());
                                                    cmd2.ExecuteNonQuery();
                                                    con.Close();

                                                    con.Open();
                                                    SqlCommand cmd = new SqlCommand("select token from groupsportdetail where teamname=@teamname ", con);
                                                    cmd.Parameters.AddWithValue("@teamname", teamname.Text);
                                                    token = (int)cmd.ExecuteScalar();
                                                    con.Close();
                                                    string[] value = { pt1.Text, pt2.Text, pt3.Text, pt4.Text, pt5.Text, pt6.Text, pt7.Text, pt8.Text, pt9.Text, pt10.Text };
                                                    for (int i = 0; i < 10; i++)
                                                    {
                                                        con.Open();
                                                        SqlCommand cmd1 = new SqlCommand("insert into groupsporteventstudentlist (token,studentid) values (@token,@studentid)", con);
                                                        cmd1.Parameters.AddWithValue("@token", token);
                                                        cmd1.Parameters.AddWithValue("@studentid", value[i]);
                                                        cmd1.ExecuteNonQuery();
                                                        con.Close();
                                                    }
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('SUCCESS!', 'Succesfully registered');", true);
                                                    }
                                                    else
                                                    {
                                                        
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','team name already taken');", true);
                                                    }
                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. should be unique...');", true);
                }


            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "swal('WARNING!','Roll no. doesnt exist...');", true);
            }

        }
        //end throwball

        public Boolean checkidexist()
        {
           
            con.Open();
            
            SqlCommand sd1 = new SqlCommand("select count(*) from groupsportdetail where courseid=@courseid and sportid= @sportid", con);
            sd1.Parameters.AddWithValue("@courseid", Deptlist.SelectedValue.ToString());
            sd1.Parameters.AddWithValue("@sportid", toursportlist.SelectedValue.ToString());

            int i = (int)sd1.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                return true;//already exist
            }
            else
            {
                return false;

            }
          
        }

    }
}