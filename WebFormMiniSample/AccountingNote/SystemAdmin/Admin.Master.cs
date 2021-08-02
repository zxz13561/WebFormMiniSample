using AccointingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) //check already press button or not
            {
                if (!AuthManager.IsLogined()) // redirect to login page if user not login
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                var currentUser = AuthManager.GetCurrecntUser();

                // if user not exist, redirect to login page
                if (currentUser == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }
            }
        }
    }
}