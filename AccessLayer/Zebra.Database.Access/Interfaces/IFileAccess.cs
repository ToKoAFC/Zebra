using System.IO;
using Zebra.CoreModels;
using Zebra.Global;

namespace Zebra.Database.Access.Interfaces
{
    public interface IFileAccess
    {
        int? UploadProductFile(CoreUploadProductFile model);
    }
}
