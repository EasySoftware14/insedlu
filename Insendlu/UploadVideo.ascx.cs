using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
//using Insendlu.Entities.Domain;

namespace Insendlu
{
    public partial class UploadVideo : UserControl
    {
        private readonly InsendluEntities _insendluEntities;

        public UploadVideo()
        {
            _insendluEntities = new InsendluEntities();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt64(Session["ID"]);

            if (FileUpload1.HasFile && FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                HttpPostedFile file = FileUpload1.PostedFile;//retrieve the HttpPostedFile object
                var buffer = new byte[file.ContentLength];
                int bytesReaded = file.InputStream.Read(buffer, 0, FileUpload1.PostedFile.ContentLength);
                //the HttpPostedFile has InputStream porperty (using System.IO;)
                //which can read the stream to the buffer object,
                //the first parameter is the array of bytes to store in,
                //the second parameter is the zero index (of specific byte) where to start storing in the buffer,
                //the third parameter is the number of bytes you want to read (do u care about this?)
                if (bytesReaded > 0)
                {
                    try
                    {
                       var upload = new Upload()
                       {
                           name = FileUpload1.FileName,
                           content_type = FileUpload1.PostedFile.ContentType,
                           created_at = DateTime.Now,
                           data = buffer,
                           modified_at = DateTime.Now,
                           user_id = (int) id,
                           file_location = file.ContentLength.ToString()
                       };

                        _insendluEntities.Uploads.Add(upload);

                        var i = _insendluEntities.SaveChanges();
                      
                        var filename = Page.Server.MapPath("~/Uploads/Tutorials/" + Path.GetFileName(file.FileName));
                        file.SaveAs(filename);
                        
                    }
                    catch (Exception ex)
                    {
                        //Label1.Text = ex.Message;
                    }
                }

            }
            else
            {
                //Label1.Text = "Choose a valid video file";
            }
        }
    }
}