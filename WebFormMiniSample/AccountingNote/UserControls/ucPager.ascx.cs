using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.UserControls
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        public string Url { get; set; }
        public int TotalSize { get; set; }  //總筆數
        public int PageSize { get; set; } //頁面比數
        public int CurrentPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int totalPages = this.GetTotalPages();

            this.ltlPage.Text = $"Total {TotalSize} datas, Total {totalPages} pages, now is page {GetCurrentPage()} </br>";

            for (var i = 1; i <= totalPages; i++)
            {
                this.ltlPage.Text += $"<a href='AccountingList.aspx?page={i}'>{i}</a>&nbsp";
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

        private int GetTotalPages()
        {
            int pagers = this.TotalSize / this.PageSize;

            if ((this.TotalSize % this.PageSize) > 0)
                pagers += 1;

            return pagers;
        }
    }
}