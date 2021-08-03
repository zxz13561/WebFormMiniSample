using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ucTest : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("ucTest-Page Init </br>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("ucTest-Page Load </br>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("ucTest-Page PreRender </br>");
        }

        protected void btnUc_Click(object sender, EventArgs e)
        {
            Response.Write("ucTest-Page btnUc_Click </br>");
        }
    }
}