using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insendlu
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var files = context.Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                System.Threading.Thread.Sleep(1000);
                HttpPostedFile file = files[i];
                var filename = context.Server.MapPath("~/Uploads/" + System.IO.Path.GetFileName(file.FileName));
                file.SaveAs(filename);
            }
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}