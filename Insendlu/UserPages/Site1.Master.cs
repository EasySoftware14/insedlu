using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insendlu.UserPages
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                var username = Session["Username"];
                userLabel.Text = username.ToString();

                if (Session["image"] != null)
                {
                    var images = Session["image"].ToString();
                    if (!string.IsNullOrEmpty(images))
                        image.Src = images;
                }

            }
        }
    }
}