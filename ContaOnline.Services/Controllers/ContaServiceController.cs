using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.Services.Controllers
{
    public class ContaServiceController : ControllerBase
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}