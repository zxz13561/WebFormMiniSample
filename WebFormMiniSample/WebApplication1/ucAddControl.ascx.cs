using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ucAddControl : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["ControlList"] != null)
            {
                Label lbl = new Label();
                lbl.ID = "Lebel1";
                lbl.Text = "Test";

                TextBox txt = new TextBox();
                txt.ID = "TextBox1";
                txt.Text = "Test";

                Button btn = new Button();
                btn.ID = "Button2";
                btn.Text = "Click";
                btn.Click += btn_Click;

                this.Controls.Add(lbl);
                this.Controls.Add(txt);
                this.Controls.Add(btn);

                this.Session["ControlList"] = null;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // 新增項目 無法findcontrol
            var txt = this.FindControl("txt1") as TextBox;
            Response.Write(txt.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label lbl = new Label();
            //lbl.ID = "Lebel1";
            //lbl.Text = "Test";

            //TextBox txt = new TextBox();
            //txt.ID = "TextBox1";
            //txt.Text = "Test";

            //Button btn = new Button();
            //btn.ID = "Button2";
            //btn.Text = "Click";
            //btn.Click += btn_Click;

            //this.Controls.Add(lbl);
            //this.Controls.Add(txt);
            //this.Controls.Add(btn);

            this.Session["ControlList"] = new string[] { "Lebel1", "TextBox1", "Button2" };
        }
    }
}