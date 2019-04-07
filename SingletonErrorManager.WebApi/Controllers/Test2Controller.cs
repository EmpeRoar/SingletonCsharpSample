using Microsoft.AspNetCore.Mvc;
using SingletonErrorManager.ErrorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingletonErrorManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        public Test2Controller()
        {

        }

        [HttpGet]
        [Route("get1/{keyword}")]
        public async Task<IActionResult> Get([FromRoute] string keyword)
        {
            return Ok(await ErrorSingleton.Instance.GetSomething(keyword));
        }

        [HttpGet]
        [Route("get2")]
        public async Task<IActionResult> Get2()
        {
            return Ok(await ErrorSingleton.Instance.GetSomething(null));
        }

        [HttpGet]
        [Route("add/{keyword}")]
        public async Task<IActionResult> Add([FromRoute] string keyword)
        {
            await ErrorSingleton.Instance.AddSomething(keyword);
            return Ok();
        }
    }
}
