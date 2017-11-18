using System.Configuration;
using Zebra.Global;

namespace Zebra.ViewModels.AdminCategory.Common
{
    public class VMFile
    {
        private static readonly string _baseImg = ConfigurationManager.AppSettings["baseImg"];
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public MimeEnum Mime { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public long Size { get; set; }

        public string IconFileUrl
        {
            get
            {
                switch (Mime)
                {
                    case MimeEnum.Pdf:
                        return _baseImg + "DataTypeIcons/pdficon.png";
                    case MimeEnum.Word:
                        return _baseImg + "DataTypeIcons/wordicon.png";
                    case MimeEnum.Odt:
                        return _baseImg + "DataTypeIcons/odticon.png";
                    case MimeEnum.Image:
                        return _baseImg + "Upload/" + FileName;
                    default:
                        return _baseImg + "DataTypeIcons/othericon.png";
                }

            }
        }
        public string Path { get; set; }
    }

}

