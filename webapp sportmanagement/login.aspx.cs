using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webapp_sportmanagement
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text=="ADMIN"&&TextBox2.Text=="ADMIN")
            {
                Session.Add("name", TextBox1.Text);
                Response.Redirect("admin_dashboard.aspx");
            }
        }
    }
}