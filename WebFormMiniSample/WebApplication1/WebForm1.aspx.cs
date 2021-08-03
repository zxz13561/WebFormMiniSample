using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("WebForm1-Page Init </br>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("WebForm1-Page Load </br>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("WebForm1-Page PreRender </br>");
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Write("WebForm1-Page btn Click </br>");
        }
    }
}