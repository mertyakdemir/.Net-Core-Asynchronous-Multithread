using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsynchronousMultithread.TaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            var myTask = new HttpClient().GetStringAsync("https://www.youtube.com/");

            var data = await myTask;

            return Ok(data);
        }
    }
}
