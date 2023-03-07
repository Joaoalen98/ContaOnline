using System.Collections.Generic;
using System.Web.Http;

namespace ContaOnline.Services.Controllers
{
    public class ContaServiceController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}