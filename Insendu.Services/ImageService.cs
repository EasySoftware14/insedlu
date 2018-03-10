using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Insendu.Services
{
    public class ImageService
    {
        public byte[] ImageToByteArray(Stream stream)
        {
            var ms = new MemoryStream();

            using (ms)
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }


        }
        public byte[] ReadToEnd(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);

            return returnImage;
        }

        //public void UploadDocuments( fileUpload)
        //{
        //    var files = fileUpload.PostedFiles;
        //    if (files.Count > 0)
        //    {
        //        for (int i = 0; i < files.Count; i++)
        //        {
        //            HttpPostedFile file = files[i];
        //            var filename = Page.Server.MapPath("~/Uploads/" + System.IO.Path.GetFileName(file.FileName));
        //            file.SaveAs(filename);

        //            var uploadDoc = new Upload()
        //            {
        //                created_at = DateTime.Now,
        //                name = file.FileName,
        //                content_type = file.ContentType,
        //                modified_at = DateTime.Now,
        //                file_location = filename

        //            };

        //            var check = _projectService.SaveDocuments(uploadDoc);
        //        }

        //    }

    }
}

