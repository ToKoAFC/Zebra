using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.Services.Interfaces
{
    public interface IFileService
    {
        int? UploadFile(VMUploadProductFile model);
    }
}