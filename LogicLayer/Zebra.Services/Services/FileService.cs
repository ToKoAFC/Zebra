using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zebra.CoreModels;
using Zebra.Database.Access;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.View.AdminCategory;

namespace Zebra.Services
{
    public class FileService
    {
        public FileAccess _fileAccess { get; set; }

        public int? UploadFile(VMUploadProductFile model)
        {
            var coreModel = new CoreUploadProductFile
            {
                FilesToUpload = model.FilesToUpload,
                Mime = model.Mime,
                ProductId = model.ProductId
            };
            return _fileAccess.UploadProductFile(coreModel);

        }
    }
}