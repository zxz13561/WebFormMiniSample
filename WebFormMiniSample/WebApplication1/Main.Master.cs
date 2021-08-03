using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("MasterPage-Page Init </br>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("MasterPage-Page Load </br>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("MasterPage-Page PreRender </br>");
        }

        protected void btnMaster_Click(object sender, EventArgs e)
        {
            Response.Write("MasterPage-Page btnMaster_Click </br>");
        }
    }
}