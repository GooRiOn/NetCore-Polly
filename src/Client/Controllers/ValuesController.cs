using System.Collections.Generic;
using System.Threading.Tasks;
using Client.HttpClients;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IExternalService _externalService;


        public ValuesController(IExternalService externalService)
            => _externalService = externalService;

        [HttpGet]
        public async Task<IEnumerable<string>> GetValuesAsync()
            => await _externalService.GetValuesAsync();
    }
}
