namespace Zebra.Services.Interfaces
{
    public interface IPriceService
    {
        void CreateCategory(string categoryName, int? parentId);
    }
}