using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insendlu
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] != null)
            {
                Response.Clear();
                Session.Abandon();
                Session.Clear();

                Response.Write("Success");
                Response.End();
            }
        }
    }
}