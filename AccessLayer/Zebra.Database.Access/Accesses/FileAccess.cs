using System;
using System.IO;
using System.Linq;
using System.Web;
using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Database.Models;
using Zebra.Global;

namespace Zebra.Database.Access
{
    public class FileAccess : IFileAccess
    {
        private readonly string directoryDest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");
        private readonly ZebraContext _context;
        public FileAccess(ZebraContext context)
        {
            _context = context;
        }

        private static byte[] ReadData(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        private static MimeEnum MimeFromString(string mime)
        {
            if (mime.Contains("image"))
            {
                return MimeEnum.Image;
            }
            else
            {
                switch (mime)
                {
                    case "application/pdf":
                        {
                            return MimeEnum.Pdf;
                        }
                    case "application/vnd.oasis.opendocument.text":
                        {
                            return MimeEnum.Odt;
                        }
                    case "application/msword":
                        {
                            return MimeEnum.Word;
                        }
                    case "text/plain":
                        {
                            return MimeEnum.Txt;
                        }
                    default:
                        {
                            return MimeEnum.Other;
                        }
                }
            }
        }

        public int? UploadProductFile(CoreUploadProductFile model)
        {

            HttpPostedFileBase file = model.FilesToUpload.FirstOrDefault();
            if (file == null)
                return -1;


            try
            {
                var product = _context.Products.FirstOrDefault(x => x.ProuductId == model.ProductId);
                if (product == null)
                {
                    return null;
                }
                var fileName = string.Format($"file_{Guid.NewGuid()}_{file.FileName}");
                string filePath = Path.Combine(directoryDest, fileName);

                File.WriteAllBytes(filePath, ReadData(file.InputStream));

                var dbFile = new DbFile
                {
                    Name = file.FileName,
                    FileName = fileName,
                    Mime = MimeFromString(file.ContentType),
                    Size = file.ContentLength

                };
                product.Files.Add(dbFile);
                _context.SaveChanges();
                return dbFile.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
