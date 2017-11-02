using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.CoreModels;
using Zebra.Database.Models;

namespace Zebra.Database.Access
{
    public class UserAccess
    {
        private readonly ZebraContext _context;
        public UserAccess(ZebraContext context)
        {
            _context = context;
        }

        public CoreUser GetUser(string userName)
        {
            var user = _context.Users.Where(x => x.UserName == userName).FirstOrDefault();
            if (user == null)
            {
                throw new Exception($"There is no user with name: {userName}");
            }
            return new CoreUser
            {
                UserId = user.Id,
                CompanyId = user.CompanyId
            };
        }
    }
}
