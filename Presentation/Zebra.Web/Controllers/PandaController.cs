using System.Collections.Generic;
using System.Web.Http;
using Zebra.ViewModels.Common;

namespace Zebra.Web.Controllers
{
    public class PandaController : ApiController
    {
        public List<VMProductBaseInfo> GetProducts()
        {
            return new List<VMProductBaseInfo>() {
                new VMProductBaseInfo
                {
                    BasePrice = "1221"
                }
            };
        }
    }
}