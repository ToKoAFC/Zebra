using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.Services
{
    public class FileService : IFileService
    {
        private readonly IFileAccess _fileAccess;
        public FileService(IFileAccess fileAccess)
        {
            _fileAccess = fileAccess;
        }

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