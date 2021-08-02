using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBFunctions;
using AccointingNote.Auth;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrecntUser();

            // if user not exist, redirect to login page
            if (currentUser == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            // read accounting data
            var dt = AccountingManager.GetAccountingList(currentUser.ID.ToString());

            if (dt.Rows.Count > 0) // check is empty data
            {
                var dtPaged = this.GetPageDataTable(dt);

                this.plcNoData.Visible = false;
                this.gvAccountList.DataSource = dtPaged;
                this.gvAccountList.DataBind();

                var pages = (dt.Rows.Count / 10);
                if (dt.Rows.Count % 10 > 0)
                    pages += 1;

                this.ltl.Text = $"Total {dt.Rows.Count} datas, Total {pages} pages, now is page {GetCurrentPage()}";
            }
            else
            {
                this.gvAccountList.Visible = false;
                this.plcNoData.Visible = true;
            }

        }

        private int GetCurrentPage()
        {
            // get what page
            string pageText = Request.QueryString["Page"];
            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }

        private DataTable GetPageDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();
            // dt.Copy() will error when no data inside data table

            foreach (DataRow dr in dt.Rows)
            {
                // create new data row
                var drNew = dtPaged.NewRow();
                foreach (DataColumn dc in dt.Columns)
                {
                    // get value
                    drNew[dc.ColumnName] = dr[dc];
                }

                // Add row data
                dtPaged.Rows.Add(drNew);
            }

            return dtPaged;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void gvAccountList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if(row.RowType == DataControlRowType.DataRow)
            {
                //Literal ltl = row.FindControl("ltActType") as Literal;
                Label lbl = row.FindControl("lblActType") as Label;
                //ltl.Text = "OK";
                var dr = e.Row.DataItem as DataRowView;
                int actType = dr.Row.Field<int>("ActType");

                if (actType == 0)
                {
                    //ltl.Text = "支出";
                    lbl.Text = "支出";
                }
                else
                {
                    //ltl.Text = "收入";
                    lbl.Text = "收入";
                }

                if(dr.Row.Field<int>("Amount") > 1500)
                {
                    lbl.ForeColor = Color.Red;
                }
            }
        }
    }
}