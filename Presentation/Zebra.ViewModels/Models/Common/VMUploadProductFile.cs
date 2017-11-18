using System.Collections.Generic;
using System.Web;
using Zebra.Global;

namespace Zebra.ViewModels.AdminCategory.Common
{
    public class VMUploadProductFile
    {
        public int ProductId { get; set; }
        public MimeEnum Mime { get; set; }
        public IEnumerable<HttpPostedFileBase> FilesToUpload { get; set; }
        public List<VMFile> Files { get; set; }
    }
}
