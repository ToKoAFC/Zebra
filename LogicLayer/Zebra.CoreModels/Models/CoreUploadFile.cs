using System.Collections.Generic;
using System.Web;
using Zebra.Global;

namespace Zebra.CoreModels
{
    public class CoreUploadProductFile
    {
        public int ProductId { get; set; }
        public MimeEnum Mime { get; set; }
        public IEnumerable<HttpPostedFileBase> FilesToUpload { get; set; }        
    }
}
