using Zebra.CoreModels;

namespace Zebra.Database.Access.Interfaces
{
    public interface IUserAccess
    {
        CoreUser GetUser(string userName);
    }
}
