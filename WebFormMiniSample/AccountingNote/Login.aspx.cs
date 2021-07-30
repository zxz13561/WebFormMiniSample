using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccointingNote.Auth;
using DBFunctions;

namespace AccountingNote
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check is already login or not
            if (this.Session["UserLoginInfo"] is null)
            {
                this.plcLogin.Visible = true;
            }
            else
            {
                this.plcLogin.Visible = true;
                Response.Redirect("/SystemAdmin/UserInfo.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Acc = this.txtAcc.Text;
            string inp_Pwd = this.txtPwd.Text;
            string msg;

            if(!AuthManager.TryLogin(inp_Acc, inp_Pwd, out msg))
            {
                this.ltlMsg.Text = msg;
                return;
            }

            Response.Redirect("/SystemAdmin/UserInfo.aspx");

        }
    }
}