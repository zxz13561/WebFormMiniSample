using AccointingNote.Auth;
using DBFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class UserInfo : System.Web.UI.Page
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

                this.ltlAcc.Text = currentUser.Account.ToString();
                this.ltlName.Text = currentUser.Name.ToString();
                this.ltlEmail.Text = currentUser.Email.ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthManager.Logout(); // Logout account
            Response.Redirect("/Login.aspx");
        }
    }
}