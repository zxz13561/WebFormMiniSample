using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccointingNote.Auth;
using AccountingNote;

namespace AccountingNote.SystemAdmin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AccointingNote.Auth.AuthManager.IsLogined())
                return;

            var cUser = AccointingNote.Auth.AuthManager.GetCurrecntUser();

            this.GridView1.DataSource = DBFunctions.AccountingManager.GetAccountingList(cUser.ID);
            this.GridView1.DataBind();
        }
    }
}