using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insendlu.Entities.Connection;

namespace Insendlu
{
    /// <summary>
    /// Summary description for VideoHandler
    /// </summary>
    public class VideoHandler : IHttpHandler
    {
        private readonly InsendluEntities _insendluEntities;

        public VideoHandler()
        {
            _insendluEntities = new InsendluEntities();
        }

        public void ProcessRequest(HttpContext context)
        {
            var id = Convert.ToInt64(context.Request.QueryString["ID"]);

            var upload = (from upl in _insendluEntities.Uploads
                            where upl.id == id
                            select upl).SingleOrDefault();

            if (upload != null)
            {
                context.Response.ContentType = upload.name;
                context.Response.BinaryWrite(upload.data);
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