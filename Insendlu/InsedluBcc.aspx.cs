using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendu.Services;

namespace Insendlu
{
    public partial class InsedluBcc : System.Web.UI.Page
    {
        private ProjectService _projectService;

        public InsedluBcc()
        {
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void bcc_OnSelectionChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void bcc_OnDayRender(object sender, DayRenderEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}